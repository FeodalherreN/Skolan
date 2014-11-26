//Markus Olsson AB7158
//2014-11-20
//Concurrent Programming, Assignment 1

using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace Uppgift_1
{
    public partial class Form1 : Form
    {
        #region Variabler
        private string SelectedPath;
        FloatingLabel fl;
        MovingTriangle mt;
        MusicPlayer player;
        Thread playmusicThread;
        Thread showDisplayThread;
        Thread moveTriangle;
        #endregion

        public Form1()
        {
            InitializeComponent();
            fl = new FloatingLabel();
            mt = new MovingTriangle();
            player = new MusicPlayer();
            trianglepicture.Load("http://upload.wikimedia.org/wikipedia/commons/6/64/Small-triangle-Armed-Forces.jpg");
        }

        #region Metoder
        /// <summary>
        /// När man trycker "open" knappen så körs en openfiledialog som sparar undan sökvägen till den fil man väljer.
        /// </summary>
        private void btnOpenMusic_Click(object sender, EventArgs e)
        {
            int size = -1;
            DialogResult result = openFileDialog1.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string file = openFileDialog1.FileName;
                try
                {
                    SelectedPath = Path.GetFullPath(file);
                    size = SelectedPath.Length;
                }
                catch (IOException)
                {

                }
                lblCurrentMusic.Text = SelectedPath.ToString();
            }
        }

        /// <summary>
        /// När man trycker "play" så görs en ny tråd av musicplayerklassens metod "playmusic". Här anges även sökvägen till musikfilen.
        /// </summary>
        private void btnPlayMusic_Click(object sender, EventArgs e)
        {
            if (SelectedPath != String.Empty)
            {
                player.FilePath = SelectedPath;
                playmusicThread = new Thread(new ThreadStart(player.PlayMusic));
                playmusicThread.Start();
            }
            else
            {
                MessageBox.Show("Please select a song to play");
            }
        }
        /// <summary>
        /// Stoppar musikspelartråden och stänger musiken.
        /// </summary>
        private void btnStopMusic_Click(object sender, EventArgs e)
        {
            if (playmusicThread != null)
            {
                player.StopMusic();
                playmusicThread.Abort();
            }
        }
        /// <summary>
        /// Startar en ny tråd av FloatingLabelklassens metod moveLabel och skickar med labelen som ska flyttas runt på skärmen.
        /// Höjd och bredd på bakgrundspictureboxen skickas även med.
        /// </summary>
        private void btnStartDisplay_Click(object sender, EventArgs e)
        {
            fl.MoveLabel = true;
            fl.Height = FloatingLabelBox.Height;
            fl.Width = FloatingLabelBox.Width;
            showDisplayThread = new Thread(() => fl.moveLabel(lblMove));
            showDisplayThread.Start();
        }

        /// <summary>
        /// Dödar labeltråden.
        /// </summary>
        private void btnStopDisplay_Click(object sender, EventArgs e)
        {
            fl.MoveLabel = false;
            if (showDisplayThread != null)
                showDisplayThread.Abort();
        }

        /// <summary>
        /// Startar en ny tråd av MovingTriangleklassens metod MoveTriangle och skickar med pictureboxen som ska flyttas runt på skärmen.
        /// Höjd och bredd på bakgrundspictureboxen skickas även med.
        /// </summary>
        private void btnStartTriangle_Click(object sender, EventArgs e)
        {
            mt.MoveTriangleBox = true;
            mt.Width = pictureBox1.Width;
            mt.Height = pictureBox1.Height;
            moveTriangle = new Thread(() => mt.MoveTriangle(trianglepicture));
            moveTriangle.Start();
        }
        /// <summary>
        /// dödar alla trådar om exitknappen trycks.
        /// </summary>
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            if (playmusicThread != null)
                playmusicThread.Abort();
            if (showDisplayThread != null)
                showDisplayThread.Abort();
            if (moveTriangle != null)
                moveTriangle.Abort();
            base.OnFormClosed(e);
        }

        /// <summary>
        /// Dödar MoveTriangle tråden.
        /// </summary>
        private void btnStopTriangle_Click(object sender, EventArgs e)
        {
            if (moveTriangle != null)
            {
                moveTriangle.Abort();
            }
        }
#endregion
    }
}
