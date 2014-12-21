using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MacServer
{
    public class ClientListener
    {
        bool listen = true; //This bool is used to close a loop later on that keeps a tcplistener alive.
        private TcpListener tcpListener; //A tcplistener.
        IPHostEntry host = Dns.GetHostEntry("localhost");
        private Thread listenThread; //A listenthread
        private MessageHandler handler;

        public ClientListener()
        {
            this.tcpListener = new TcpListener(IPAddress.Any, 1337); //Creates a TCPlistener that listens for any Ipadress but port 9998.
            this.listenThread = new Thread(new ThreadStart(ListenForClients)); //New thread that will listen for clients.
            this.listenThread.IsBackground = true; //Sets the thread to a background process.
            this.listenThread.Start(); //Starts the listenerthread.
            handler = new MessageHandler();
        }
        public void ListenForClients() //A method that loops aslong as listen is true.
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
