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

namespace MacChatServer
{
    public partial class Form1 : Form
    {
        bool listen = true; //This bool is used to close a loop later on that keeps a tcplistener alive.
        Dictionary<string, object> klienter = new Dictionary<string, object>(); //A new dictionary with strings and objects. The string is the username and object is the client.
        private TcpListener tcpListener; //A tcplistener.
        private Thread listenThread; //A listenthread
        private MessageHandler handler;

        public Form1()
        {
            InitializeComponent();
            this.tcpListener = new TcpListener(IPAddress.Any, 9998); //Creates a TCPlistener that listens for any Ipadress but port 9998.
            this.listenThread = new Thread(new ThreadStart(ListenForClients)); //New thread that will listen for clients.
            this.listenThread.IsBackground = true; //Sets the thread to a background process.
            this.listenThread.Start(); //Starts the listenerthread.
            handler = new MessageHandler();
        }
        private void ListenForClients() //A method that loops aslong as listen is true.
        {
            this.tcpListener.Start(); //starts the tcplistener

            while (listen)
            {
                //blocks until a client has connected to the server
                TcpClient client = this.tcpListener.AcceptTcpClient();
                handler.HandleCommunication(client);
                //Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                //clientThread.Start(client);
            }
        }
    }
}
