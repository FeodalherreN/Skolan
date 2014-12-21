using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MacChatClient
{
    public partial class Form1 : Form
    {
        private TcpClient client = new TcpClient(); //New instance of a tcpclient (client)
        private Thread getmessages; //A thread that will be used to continiously read from the server.
        private MessageHandler handler;

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing;
        }

        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (handler != null)
                handler.Logout();
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            handler.SendLobbyMessage(txtMessage.Text);
            txtMessage.Text = String.Empty; //Clears the textbox.
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            txtMessage.Enabled = true;
            btnSend.Enabled = true;
            btnUpdate.Enabled = true;
            handler = new MessageHandler(listUsers, listMessages);
            this.getmessages = new Thread(new ThreadStart(handler.ListenForMessages)); //Starts the thread get messages as handleservercomm.
            this.getmessages.IsBackground = true; //Makes it a background process for correct shutdown of program.
            this.getmessages.Start(); //Starts the getmessages.
            handler.Login(txtUsername.Text);
            btnConnect.Enabled = false;
            txtUsername.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            handler.SendLobbyMessage(txtUsername.Text);
        }
    }
}
