using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Library;

namespace MacChatClient
{
    /// <summary>
    /// This class represents the communication between the client and the server through messaging.
    /// </summary>
    public class MessageHandler
    {
        private TcpClient client = new TcpClient(); //New instance of a tcpclient (client)
        private IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(StaticValuesAndMethods.ip), 1337); //Defining the ip and port to server for later use.
        private IPEndPoint localEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1337); //A local test endpoint. 
        private ListBox userList; //Listbox for the users
        private ListBox messageList; //Listbox for the lobbymessages.
        private User user; //A user to be set to the current user.
        private delegate void UpdateGUIDelagate(Library.HeartBeat piHeartBeat); //An updatedelegate that takes a heartbeatobject.

        public MessageHandler(ListBox piUserList, ListBox piMessageList)
        {
            this.userList = piUserList;
            this.messageList = piMessageList;
            
        }

        /// <summary>
        /// This method connects to the ipEndpoint given.
        /// </summary>
        /// <returns>True if successful, otherwise false.</returns>
        private bool Connect()
        {
            try { this.client.Connect(localEndPoint); return true; } //Connect to the pre-defined ip and port, which is the server.
            catch (Exception e) { MessageBox.Show("Det gick inte att nå måldatorn."); return false; }
        }

        /// <summary>
        /// This is the method used to listen for server messagepassing.
        /// It uses a threadpool to handle threading.
        /// </summary>
        public void ListenForMessages()
        {
            if (!Connect()) //Tries to connect to the server at first.
                return;
                 ThreadPool.QueueUserWorkItem(_ =>
            {
                User user = new User("placeholder"); //Creates a placeholder user.
                NetworkStream clientSockStream = client.GetStream();  //New stream from the server
                try
                {
                    while (clientSockStream.CanRead) //Aslong as it can read from the server...
                    {
                        try
                        {
                            int bytesRead = 0;
                            byte[] bytes = new byte[4096]; //bytebuffer
                            bytesRead = clientSockStream.Read(bytes, 0, 4096); //reads the data from server
                            dynamic message = StaticValuesAndMethods.ByteArrayToObject(bytes); //Dynamic message from server, can be different kinds of messages...
                            if (message is Library.HeartBeat) //If the message is a HeartBeat..
                            {
                                //Updates the lists with new information on heartbeats. Lobbymessages, users..
                                messageList.Invoke(new UpdateGUIDelagate(UpdateUserList), new object[] { message });
                            }
                            if (message is Library.PrivateMessage) //If the message is a PrivateMessage..
                            {
                                string tempmessage = message.MessageText;
                                string[] temparray = tempmessage.Split(' ');
                                tempmessage = "";
                                for (int i = 1; i < temparray.Length; i++)
                                {
                                    tempmessage += temparray[i] + " ";
                                }
                                MessageBox.Show(tempmessage, "Message from: " + message.Sender.Username); //shows a messagebox with the information from the privatemessage..
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex);
                        }
                        Thread.Sleep(50);
                    }
                }
                catch (SocketException ex)
                {
                    Console.WriteLine(ex);
                }
                finally
                {
                    if (client != null)
                    {
                        client.Close(); //Closes the client
                        clientSockStream.Close(); //Closes the stream
                    }
                }

            });
        }
        /// <summary>
        /// This method registers the user in the server.
        /// </summary>
        /// <param name="username"></param>
        /// <returns>True if successful, otherwise false.</returns>
        public bool Login(string username)
        {
            Library.ConnectAttempt connect; //ConnectAttempObject.
            try
            {
                connect = new ConnectAttempt(username); //New instance of ConnectAttempObject with given username..
                user = new User(connect.User.Username); //sets the user to given username.
                byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(connect); //Converts the object to bytearray.
                NetworkStream clientStream = client.GetStream(); //creates a networkstream from the client.
                ASCIIEncoding encoder = new ASCIIEncoding(); //ASCII encoder
                clientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
                clientStream.Flush(); //Flushes the stream
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a privatemessage from information given and sends to server.
        /// </summary>
        /// <param name="reciever"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendPrivateMessage(string reciever, string msg)
        {
            Library.PrivateMessage message; //Privatemessage
            try
            {
                message = new Library.PrivateMessage(msg, DateTime.Now, user, new User(reciever)); //new instance of privatemessage
                byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(message); //Converts the privatemessage to a bytearray.
                NetworkStream clientStream = client.GetStream(); //creates a networkstream from the client.
                ASCIIEncoding encoder = new ASCIIEncoding(); //ASCII encoder
                clientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
                clientStream.Flush(); //Flushes the stream
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// Creates a lobbymessage from information given and sends to server.
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public bool SendLobbyMessage(string msg)
        {
            Library.LobbyMessage message; //Lobbymessage
            try
            {
                message = new Library.LobbyMessage(msg, DateTime.Now, user); //New instance of lobbymessage
                byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(message); //Converts lobbymessage to bytearray
                NetworkStream clientStream = client.GetStream(); //creates a networkstream from the client.
                ASCIIEncoding encoder = new ASCIIEncoding(); //ASCII encoder
                clientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
                clientStream.Flush(); //Flushes the stream
                return true;
            }
            catch(Exception e)
            {
                return false;
            }
        }
        /// <summary>
        /// This method logs the user out from the server.
        /// </summary>
        public void Logout()
        {
            try
            {
                Library.LogoutAttempt message = new Library.LogoutAttempt(); //A logoutattempobject
                byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(message); //Convert logoutobjectobject to byte array
                NetworkStream clientStream = client.GetStream(); //creates a networkstream from the client.
                ASCIIEncoding encoder = new ASCIIEncoding(); //ASCII encoder
                clientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
                clientStream.Flush(); //Flushes the stream
            }
            catch
            {

            }
        }
        /// <summary>
        /// Method used to invoke GUI with heartbeat information.
        /// </summary>
        /// <param name="piHeartBeat"></param>
        private void UpdateUserList(Library.HeartBeat piHeartBeat)
        {
            userList.Items.Clear();
            //Updates the userlist
            foreach (User user in piHeartBeat.UserList)
            {
                if(user.Username != null)
                    userList.Items.Add(user.Username);
            }
            messageList.Items.Clear();
            //Updates the lobbymessagelist
            foreach (LobbyMessage msg in piHeartBeat.LobbyMessages)
            {
                messageList.Items.Add(msg.Sender.Username + ": " + msg.MessageText);
            }
        }
    }
}
