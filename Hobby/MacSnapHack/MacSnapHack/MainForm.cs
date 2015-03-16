using MacSnapHack.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacSnapHack
{
    public partial class MainForm : Form
    {
        private Tuple<TempEnumHolder.LoginStatus, Account> CurrentUser;
        AutoUpdater au;
        Thread UpdateThread;
        private Form ivLoginForm;
        public MainForm()
        {
            InitializeComponent();
            FormClosing += MainForm_FormClosing;
        }
        void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
        public void StartAutoUpdating()
        {
           au = new AutoUpdater(CurrentUser.Item2.UserName, CurrentUser.Item2.AuthToken, listUserInfo, 
               listFriends, listSnaps, listDownload, btnDownload, lblAvailabeSnaps, this, ivLoginForm);
           UpdateThread = new Thread(au.Update);
           UpdateThread.IsBackground = true;
           UpdateThread.Start();
        }
        public Tuple<TempEnumHolder.LoginStatus, Account> User
        {
            get { return CurrentUser; }
            set { CurrentUser = value; }
        }
        public Form LoginForm
        {
            get { return ivLoginForm; }
            set { ivLoginForm = value; }
        }
        private void btnDownload_Click(object sender, EventArgs e)
        {
            au.Download();
        }

        private void CbAutoDowload_CheckedChanged(object sender, EventArgs e)
        {
            if (CbAutoDowload.Checked)
            {
                au.EnableAutoDownload = true;
                btnDownload.Enabled = false;
            }
            else
            {
                au.EnableAutoDownload = false;
                btnDownload.Enabled = true;
            }
        }

        private void CbNotification_CheckedChanged(object sender, EventArgs e)
        {
            if (CbNotification.Checked)
                au.EnableNotifications = true;
            else
                au.EnableNotifications = false;
        }

        private void CbDebug_CheckedChanged(object sender, EventArgs e)
        {
            if (CbDebug.Checked)
                au.EnableDebugging = true;
            else
                au.EnableDebugging = false;
        }

        private void btnOpenFolder_Click(object sender, EventArgs e)
        {
            au.CheckDirectory();
            System.Diagnostics.Process.Start("explorer", Environment.CurrentDirectory + "\\Snaps");
        }
    }
}
