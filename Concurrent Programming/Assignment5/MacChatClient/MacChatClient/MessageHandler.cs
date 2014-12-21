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
    public class MessageHandler
    {
        private TcpClient client = new TcpClient(); //New instance of a tcpclient (client)
        private IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(StaticValuesAndMethods.ip), 1337); //Defining the ip and port to server for later use.
        private ListBox userList;
        private ListBox messageList;
        private User user;
        private delegate void UpdateGUIDelagate(Library.HeartBeat piHeartBeat);

        public MessageHandler(ListBox piUserList, ListBox piMessageList)
        {
            this.userList = piUserList;
            this.messageList = piMessageList;
            
        }
        private bool Connect()
        {
            try { this.client.Connect(serverEndPoint); return true; } //Connect to the pre-defined ip and port, which is the server.
            catch (Exception e) { MessageBox.Show("Det gick inte att nå måldatorn."); return false; }
        }

        public void ListenForMessages()
        {
            if (!Connect())
                return;
                 ThreadPool.QueueUserWorkItem(_ =>
            {
                User user = new User("placeholder");
                NetworkStream clientSockStream = client.GetStream();
                try
                {
                    while (clientSockStream.CanRead)
                    {
                        try
                        {
                            int bytesRead = 0;
                            clientSockStream = client.GetStream();
                            byte[] bytes = new byte[4096];
                            bytesRead = clientSockStream.Read(bytes, 0, 4096);
                            dynamic message = StaticValuesAndMethods.ByteArrayToObject(bytes);
                            if(message is Library.HeartBeat)
                            {
                                messageList.Invoke(new UpdateGUIDelagate(UpdateUserList), new object[] { message });
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
                        client.Close();
                        clientSockStream.Close();
                    }
                }

            });
        }
        public bool Login(string username)
        {
            Library.ConnectAttempt connect;
            try
            {
                connect = new ConnectAttempt(username);
                user = new User(connect.User.Username);
                byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(connect);
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
        public bool SendLobbyMessage(string msg)
        {
            Library.LobbyMessage message;
            try
            {
                message = new Library.LobbyMessage(msg, DateTime.Now, user);
                byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(message);
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
        public void Logout()
        {
            try
            {
                Library.LogoutAttempt message = new Library.LogoutAttempt();
                byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(message);
                NetworkStream clientStream = client.GetStream(); //creates a networkstream from the client.
                ASCIIEncoding encoder = new ASCIIEncoding(); //ASCII encoder
                clientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
                clientStream.Flush(); //Flushes the stream
            }
            catch
            {

            }
        }
        private void UpdateUserList(Library.HeartBeat piHeartBeat)
        {
            userList.Items.Clear();
            foreach (User user in piHeartBeat.UserList)
            {
                if(user.Username != null)
                    userList.Items.Add(user.Username);
            }
            messageList.Items.Clear();
            foreach (LobbyMessage msg in piHeartBeat.LobbyMessages)
            {
                messageList.Items.Add(msg.Sender.Username + ": " + msg.MessageText);
            }
        }
    }
}
