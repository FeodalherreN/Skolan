using Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MacServer
{
    /// <summary>
    /// This class controls the incoming communication from the clients and sends information back.
    /// </summary>
    public class MessageHandler
    {
        private Dictionary<TcpClient, User> ivUserList; //A dictionary to keep track of the users connected.
        ASCIIEncoding encoder; //An ascii encoder.
        private List<Library.LobbyMessage> ivlobbyMessageList; //a lobbymessagelist

        public MessageHandler()
        {
            ivUserList = new Dictionary<TcpClient, User>();
            encoder = new ASCIIEncoding();
            ivlobbyMessageList = new List<LobbyMessage>();
        }

        /// <summary>
        /// This method listens for users and communicates with them using a threadpool.
        /// </summary>
        /// <param name="client"></param>
        public void HandleCommunication(TcpClient client)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                User user = new User("placeholder"); //a new placeholderuser.
                if (ivUserList.ContainsKey(client)) //checks if the user already exists.
                {
                    user = ivUserList[client];
                }
                NetworkStream clientSockStream = client.GetStream(); // A new networkstream from client.
                try
                {
                    while (clientSockStream.CanRead) //While it can read from client.
                    {
                        try
                        {
                            int bytesRead = 0;
                            byte[] bytes = new byte[4096]; //A bytebuffer
                            bytesRead = clientSockStream.Read(bytes, 0, 4096); //reads the incoming message
                            dynamic message = StaticValuesAndMethods.ByteArrayToObject(bytes); //Converts the message to an object.
                            if(message is Library.ConnectAttempt) //If the object is a connectionattempt.
                            {
                                TcpClient Reciever = client; //saves the client as new tcpclient.
                                if (!ivUserList.ContainsKey(client)) //checks if the userlist contains the user.
                                {
                                    ivUserList.Add(client, message.User); //If it doesnt, add the user.
                                    Console.WriteLine(message.User.Username + " connected.."); //Write to console that the user x connected.
                                }
                                else
                                {
                                    ivUserList[client].Username = message.User.Username;
                                }
                                SendHeartbeat(client); //Starts sending heartbeats to client.
                            }
                            if(message is Library.LogoutAttempt) //If message is a logoutattempt.
                            {
                                Console.WriteLine(ivUserList[client].Username + " logged out..."); //Write this to console.
                                ivUserList.Remove(client); //remove the client from the userlist.
                            }
                            if(message is Library.LobbyMessage) // If message is a lobbymessage
                            {
                                 ivlobbyMessageList.Add(message); //Add it to the lobbylist
                            }
                            if(message is Library.PrivateMessage) // If message is a privatemessage
                            {
                                foreach (KeyValuePair<TcpClient, User> entry in ivUserList) //CHeck the dictionary if the reciever exists
                                {
                                    if (entry.Value.Username == message.Reciever.Username) //If match
                                    {
                                        TcpClient Reciever = entry.Key; //get the client
                                        NetworkStream recieverClientStream = Reciever.GetStream(); // start a stream
                                        if (recieverClientStream.CanRead) //Check if the stream can read
                                        {
                                            byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(message); //Convert the object to bytearray again
                                            recieverClientStream.Write(buffer, 0, buffer.Length); //Sends the message to reciever
                                            recieverClientStream.Flush(); //Flushes the stream
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            break;
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
        /// <summary>
        /// This method is started once a client connects. It sends information each half second to the user.
        /// It uses a threadpool to do so.
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        private async Task SendHeartbeat(TcpClient client)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    NetworkStream clientSockStream = client.GetStream(); //Starts a new networkstream to the client
                    while (clientSockStream.CanRead) //While it can read.
                    {
                        try
                        {
                            int bytesRead = 0;
                            clientSockStream = client.GetStream(); 
                            byte[] bytes = new byte[4096]; // Byte buffer
                            List<User> userList = new List<User>(); //list to store users from dictionary in
                            foreach (User us in ivUserList.Values) //Loops all users in dictionary
                            {
                                userList.Add(us); //Adds to new list
                            }
                            Library.HeartBeat heartbeat = new HeartBeat(userList, ivlobbyMessageList); //Creats a heartbeatobject
                            byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(heartbeat); //Converts the object to bytearray.
                            clientSockStream.Write(buffer, 0, buffer.Length); //sends it.
                            clientSockStream.Flush();
                        }
                        catch (Exception e)
                        {

                        }
                        Thread.Sleep(500);
                    }
                }
                catch (Exception e)
                {

                }
            });
        }
    }
}
