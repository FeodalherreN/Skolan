using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MacChatServer
{
    public class User
    {
        private string ivUsername;
        private TcpClient ivTcpClient;
        private List<Message> ivMessages;

        public User(string piUsername, TcpClient piTcpClient)
        {
            this.ivUsername = piUsername;
            this.ivTcpClient = piTcpClient;
            this.ivMessages = new List<Message>();
        }

        public string Username
        {
            get { return ivUsername; }
            set { ivUsername = value; }
        }
        public TcpClient TcpClient
        {
            get { return ivTcpClient; }
            set { ivTcpClient = value; }
        }
        public List<Message> Messages
        {
            get { return ivMessages; }
            set { ivMessages = value; }
        }
    }
}
