using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
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
        public User User
        {
            get { return user; }
            set { user = value; }
        }
    }
}
