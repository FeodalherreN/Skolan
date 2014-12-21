using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
    public class LogoutAttempt
    {
        private bool logout;

        public LogoutAttempt()
        {

        }
        public LogoutAttempt(bool piLogoutAttempt)
        {
            this.logout = piLogoutAttempt;
        }
    }
}
