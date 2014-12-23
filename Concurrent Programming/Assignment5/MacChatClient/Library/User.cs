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
    /// <summary>
    /// This class represents a user in the system.
    /// </summary>
    [Serializable]
    public class User
    {
        private string ivUsername; //A username
        private List<PrivateMessage> ivMessages; //list of messages.

        public User()
        {

        }

        public User(string piUsername)
        {
            this.ivUsername = piUsername;
            this.ivMessages = new List<PrivateMessage>();
        }

        /// <summary>
        /// Property for the username.
        /// </summary>
        public string Username
        {
            get { return ivUsername; }
            set { ivUsername = value; }
        }
        /// <summary>
        /// Property for the users list of messages.
        /// </summary>
        public List<PrivateMessage> Messages
        {
            get { return ivMessages; }
            set { ivMessages = value; }
        }
    }
}
