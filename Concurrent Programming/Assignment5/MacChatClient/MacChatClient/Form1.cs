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
        private MessageHandler handler; //A messagehandler

        public Form1()
        {
            InitializeComponent();
            this.FormClosing += Form1_FormClosing; //Bind default onclosing behaviour
            this.listUsers.SelectedIndexChanged += listUsers_SelectedIndexChanged; //Handle selected index on userlist.
            this.AcceptButton = btnSend; //Set the acceptbutton to sendbutton.
            this.listMessages.Items.Add("Write @username to send privatemessages..."); //A hint at startup.
        }

        /// <summary>
        /// Handles SelectedIndexChanged and sets the prefix to the user chosen for privatemessaging.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void listUsers_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listUsers.SelectedItem != null) 
            {
                txtMessage.Text = "";
                txtMessage.Text = "@" + listUsers.SelectedItem + " "; //Sets the txtMessage to @<username>
            }
        }

        /// <summary>
        /// Sets the deaultbehavious of formclosing. Sends a logoutmessage to the server.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (handler != null)
                handler.Logout();
        }

        /// <summary>
        /// Onclick event on send button. Checks if prefix for privatemessage is set, then sends privatemessage. Otherwise it sends a lobbymessage.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSend_Click(object sender, EventArgs e)
        {
            if (txtMessage.Text != "") //Initial check if textbox for message is empty..
            {
                string[] msgType = txtMessage.Text.Split(' '); //Splits the message to string array.
                if (msgType[0][0] == '@') //Checks if first char in first word is an @
                {
                    string reciever = msgType[0].Substring(1); //sets the first string -@ to username.
                    handler.SendPrivateMessage(reciever, txtMessage.Text); //Sends private message to username via server.
                }
                else
                {
                    handler.SendLobbyMessage(txtMessage.Text); //Sends lobbymessage.
                }
                txtMessage.Text = String.Empty; //Clears the textbox.
            }
        }

        /// <summary>
        /// Handles when the user clicks connect 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            if (txtUsername.Text != "")
            {
                txtMessage.Enabled = true;
                btnSend.Enabled = true;
                handler = new MessageHandler(listUsers, listMessages); // New instance of messagehandler.
                this.getmessages = new Thread(new ThreadStart(handler.ListenForMessages)); //Starts the thread get messages as ListenForMessages.
                this.getmessages.IsBackground = true; //Makes it a background process for correct shutdown of program.
                this.getmessages.Start(); //Starts the getmessages.
                handler.Login(txtUsername.Text); //Calls for login.
                btnConnect.Enabled = false;
                txtUsername.Enabled = false;
            }
            else
                MessageBox.Show("Please choose a username.");
        }
    }
}
