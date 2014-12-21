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
    public class MessageHandler
    {
        private Dictionary<TcpClient, User> ivUserList;
        ASCIIEncoding encoder;
        private delegate void UpdateGUIDelagate();
        private List<Library.LobbyMessage> ivlobbyMessageList;

        public MessageHandler()
        {
            ivUserList = new Dictionary<TcpClient, User>();
            encoder = new ASCIIEncoding();
            ivlobbyMessageList = new List<LobbyMessage>();
        }


        public void HandleCommunication(TcpClient client)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                User user = new User("Anonymous");
                if (ivUserList.ContainsKey(client))
                {
                    user = ivUserList[client];
                }
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
                            if(message is Library.ConnectAttempt)
                            {
                                TcpClient Reciever = client;
                                if (!ivUserList.ContainsKey(client))
                                {
                                    ivUserList.Add(client, message.User);
                                    Console.WriteLine(message.User.Username + " connected..");
                                }
                                else
                                {
                                    ivUserList[client].Username = message.User.Username;
                                }
                                SendHeartbeat(client);
                            }
                            if(message is Library.LogoutAttempt)
                            {
                                Console.WriteLine(ivUserList[client].Username + " logged out...");
                                ivUserList.Remove(client);
                            }
                            if(message is Library.LobbyMessage)
                            {
                                 ivlobbyMessageList.Add(message);
                            }
                            if(message is Library.PrivateMessage)
                            {
                                foreach (KeyValuePair<TcpClient, User> entry in ivUserList)
                                {
                                    if (entry.Value.Username == message.Reciever.Username)
                                    {
                                        TcpClient Reciever = entry.Key;
                                        NetworkStream recieverClientStream = Reciever.GetStream();
                                        if (recieverClientStream.CanRead)
                                        {
                                            byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(message); //a byte array to store the message in after it has been encoded.
                                            recieverClientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
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
        private async Task SendHeartbeat(TcpClient client)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                try
                {
                    NetworkStream clientSockStream = client.GetStream();
                    while (clientSockStream.CanRead)
                    {
                        try
                        {
                            int bytesRead = 0;
                            clientSockStream = client.GetStream();
                            byte[] bytes = new byte[4096];
                            List<User> userList = new List<User>();
                            foreach (User us in ivUserList.Values)
                            {
                                userList.Add(us);
                            }
                            Library.HeartBeat heartbeat = new HeartBeat(userList, ivlobbyMessageList);
                            byte[] buffer = StaticValuesAndMethods.ObjectToByteArray(heartbeat);
                            clientSockStream.Write(buffer, 0, buffer.Length);
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
        private void UpdateConsole()
        {

        }
    }
}
