using MacSnapHack.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacSnapHack
{
    public class AutoUpdater
    {
        private string ivUsername;
        private string ivAuthToken;
        private bool ivDebugMode = false;
        private bool ivAutoDownload = false;
        private bool ivNotify = false;
        private Account CurrentUser;
        private ListBox ivListUserInfo;
        private ListBox ivListFriends;
        private ListBox ivListSnaps;
        private ListBox ivListDownload;
        private Button ivBtnDownload;
        private Label ivAvailableSnapsLabel;
        private Form ivMainform;
        private Form ivLoginForm;

        private delegate void DisplayDelegate();

        public AutoUpdater(string piUsername, string piAuthToken, ListBox piListUserInfo, ListBox piListFriends,
            ListBox piListSnaps, ListBox piListDownload, Button piBtnDownload, Label piAvailableSnapsLabel, Form piMainForm,
            Form piLoginForm)
        {
            this.ivUsername = piUsername;
            this.ivAuthToken = piAuthToken;
            this.ivListUserInfo = piListUserInfo;
            this.ivListFriends = piListFriends;
            this.ivListSnaps = piListSnaps;
            this.ivListDownload = piListDownload;
            this.ivBtnDownload = piBtnDownload;
            this.ivAvailableSnapsLabel = piAvailableSnapsLabel;
            this.ivMainform = piMainForm;
            this.ivLoginForm = piLoginForm;
        }
        public void UpdateUserInfo()
        {
            //Update Userinfo
            ivListUserInfo.Items.Clear();
            ivListUserInfo.Items.Add("Username:         " + CurrentUser.UserName);
            ivListUserInfo.Items.Add("Email:            " + CurrentUser.Email);
            ivListUserInfo.Items.Add("New Snaps:        " + CurrentUser.Recieved);
            ivListUserInfo.Items.Add("Sent Snaps:       " + CurrentUser.Sent);
            ivListUserInfo.Items.Add("Score:            " + CurrentUser.Score);
            ivListUserInfo.Items.Add("Snap number:     " + CurrentUser.SnapchatPhoneNumber);
        }
        private void UpdateFriendInfo()
        {
            //Update Friendlist
            ivListFriends.Items.Clear();
            foreach (var friend in CurrentUser.Friends)
            {
                ivListFriends.Items.Add(friend.Name + "    " + friend.Display + "    " + friend.Type);
            }
        }
        private void UpdateSnapsInfo()
        {
            //Update Snaps
            ivListSnaps.Items.Clear();
            foreach (var Snap in CurrentUser.Snaps)
            {
                if (Snap.RecipientName != null)
                {
                    ivListSnaps.Items.Add(Snap.RecipientName + Snap.CaptionText + "      " + Snap.Status);
                }
            }
        }
        private void UpdateAvailableSnapsLabel()
        {
            int localCount = 0;
            foreach (Snap snap in CurrentUser.Snaps)
            {
                if (CurrentUser.UserName != snap.ScreenName && snap.ScreenName != null && snap.Status == SnapStatus.Delivered)
                {
                    localCount++;
                }
            }
            ivAvailableSnapsLabel.Text = "Available snaps: " + localCount + ".";
        }
        public void Logout()
        {
            ivLoginForm.Show();
            MessageBox.Show("You have been logged out.");
            ivMainform.Visible = false;
        }
        public bool CheckLoginStatus()
        {
            if (CurrentUser == null)
            {
                ivMainform.Invoke(new DisplayDelegate(Logout));
                return false;
            }
            return true;
        }
        public async void Update()
        {
            while (true)
            {
                CurrentUser = await Methods.Update(ivUsername, ivAuthToken);
                if (!CheckLoginStatus())
                    break;
                CheckLoginStatus();
                ivListUserInfo.Invoke(new DisplayDelegate(UpdateUserInfo));
                ivListFriends.Invoke(new DisplayDelegate(UpdateFriendInfo));
                ivListSnaps.Invoke(new DisplayDelegate(UpdateSnapsInfo));
                ivAvailableSnapsLabel.Invoke(new DisplayDelegate(UpdateAvailableSnapsLabel));

                if (ivAutoDownload)
                    ivListDownload.Invoke(new DisplayDelegate(Download));

                Thread.Sleep(20000);
            }
        }
        public async void Download()
        {
            if (!CheckLoginStatus())
                return;
            ivListDownload.Items.Clear();
            CheckDirectory();
            int localCount = 0;
            if(!ivAutoDownload)
               ivBtnDownload.Enabled = false;
            foreach (Snap snap in CurrentUser.Snaps)
            {
                if (CurrentUser.UserName != snap.ScreenName && snap.ScreenName != null && snap.Status == SnapStatus.Delivered)
                {
                    byte[] snapdata = await Methods.GetBlob(snap.Id, CurrentUser.UserName, CurrentUser.AuthToken);
                    if (snap.MediaType == MediaType.Image || snap.MediaType == MediaType.FriendRequestImage)
                    {
                        string path = Directory.GetCurrentDirectory() + "\\Snaps\\" + snap.Id + ".jpeg";
                        if (!File.Exists(path))
                        {
                            try
                            {
                                ivListDownload.Items.Add("Downloading image..." + snap.Id + " from " + snap.ScreenName);
                                System.IO.FileStream fs = new System.IO.FileStream("Snaps\\" + snap.Id + ".jpeg", System.IO.FileMode.CreateNew);
                                fs.Write(snapdata, 0, snapdata.Length);
                                fs.Close();
                                localCount++;
                                if(ivNotify)
                                {
                                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                                    player.SoundLocation = Directory.GetCurrentDirectory() + "\\Notification\\notification.wav";
                                    player.Play();
                                }
                            }
                            catch(Exception exception)
                            {
                                if (ivDebugMode)
                                ivListDownload.Items.Add(exception.Message);
                            }
                        }
                    }
                    if(snap.MediaType == MediaType.Video || snap.MediaType == MediaType.VideoNoAudio || snap.MediaType == MediaType.FriendRequestVideo
                        || snap.MediaType == MediaType.FriendRequestVideoNoAudio)
                    {
                        string path = Directory.GetCurrentDirectory() + "\\Snaps\\" + snap.Id + ".avi";
                        if (!File.Exists(path))
                        {
                            try
                            {
                                ivListDownload.Items.Add("Downloading video..." + snap.Id + " from " + snap.ScreenName);
                                System.IO.FileStream fs = new System.IO.FileStream("Snaps\\" + snap.Id + ".avi", System.IO.FileMode.CreateNew);
                                fs.Write(snapdata, 0, snapdata.Length);
                                fs.Close();
                                localCount++;
                                if (ivNotify)
                                {
                                    System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                                    player.SoundLocation = Directory.GetCurrentDirectory() + "\\Notification\\notification.wav";
                                    player.Play();
                                }
                            }
                            catch(Exception exception)
                            {
                                if(ivDebugMode)
                                ivListDownload.Items.Add(exception.Message);
                            }
                        }
                    }
                }
            }
            ivListDownload.Items.Add("Finished downloading " + localCount + " files");
            if (!ivAutoDownload)
                ivBtnDownload.Enabled = true;
        }
        public void CheckDirectory()
        {
            if(!File.Exists(Environment.CurrentDirectory + "\\Snaps"))
            {
                Directory.CreateDirectory(Environment.CurrentDirectory + "\\Snaps");
            }
        }
        public Account User
        {
            get { return CurrentUser; }
            set { CurrentUser = value; }
        }
        public bool EnableDebugging
        {
            get { return ivDebugMode; }
            set { ivDebugMode = value; }
        }
        public bool EnableAutoDownload
        {
            get { return ivAutoDownload; }
            set { ivAutoDownload = value; }
        }
        public bool EnableNotifications
        {
            get { return ivNotify; }
            set { ivNotify = value; }
        }
    }
}
