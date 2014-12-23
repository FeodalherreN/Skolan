using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// This method is used to logout from the server.
    /// </summary>
    [Serializable]
    public class LogoutAttempt
    {
        private bool logout;

        public LogoutAttempt()
        {

        }
        /// <summary>
        /// Property that sets the logoutbool.
        /// </summary>
        /// <param name="piLogoutAttempt"></param>
        public LogoutAttempt(bool piLogoutAttempt)
        {
            this.logout = piLogoutAttempt;
        }
    }
}
