using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
    public class User
    {
        private string ivUsername;
        private List<Message> ivMessages;

        public User()
        {

        }
        public User(string piUsername, TcpClient piTcpClient)
        {
            this.ivUsername = piUsername;
            this.ivMessages = new List<Message>();
        }

        public string Username
        {
            get { return ivUsername; }
            set { ivUsername = value; }
        }
        public List<Message> Messages
        {
            get { return ivMessages; }
            set { ivMessages = value; }
        }
    }
}
