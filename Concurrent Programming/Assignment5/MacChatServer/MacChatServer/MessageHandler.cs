using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MacChatServer
{
    public class MessageHandler
    {
        private List<User> ivUserList;
        ASCIIEncoding encoder;

        public MessageHandler()
        {
            ivUserList = new List<User>();
            encoder = new ASCIIEncoding();
        }


        public void HandleCommunication(TcpClient client)
        {
            ThreadPool.QueueUserWorkItem(_ =>
            {
                User user = new User("placeholder", client);
                foreach(User us in ivUserList)
                {
                    if(us.TcpClient == client)
                    {
                        user = us;
                    }
                }
                NetworkStream clientSockStream = client.GetStream();
                try
                {
                    while (clientSockStream.CanRead)
                    {
                        int bytesRead = 0;
                        clientSockStream = client.GetStream();
                        byte[] bytes = new byte[4096];
                        try
                        {
                            bytesRead = clientSockStream.Read(bytes, 0, 4096);
                            Message message = StaticValuesAndMethods.DeserializeFromXml<Message>(System.Text.Encoding.ASCII.GetString(bytes, 0, bytesRead));
                            user.Messages.Add(message);

                            NetworkStream recieverClientStream = message.Reciever.TcpClient.GetStream();
                            if(recieverClientStream.CanRead)
                            {
                                byte[] buffer = StaticValuesAndMethods.MessageToByteArray(message); //a byte array to store the message in after it has been encoded.
                                recieverClientStream.Write(buffer, 0, buffer.Length); //Sends the message to server
                                recieverClientStream.Flush(); //Flushes the stream
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
    }
}
