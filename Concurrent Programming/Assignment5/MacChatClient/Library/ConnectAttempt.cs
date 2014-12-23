using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// This class represents a connectionattempt from a user.
    /// It is used of the server to register the user in the system.
    /// </summary>
    [Serializable]
    public class ConnectAttempt
    {
        private User user;

        public ConnectAttempt()
        {
            user = new User();
        }
        public ConnectAttempt(string Username)
        {
            user = new User(Username);
        }
        /// <summary>
        /// A property to set the user connecting.
        /// </summary>
        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
