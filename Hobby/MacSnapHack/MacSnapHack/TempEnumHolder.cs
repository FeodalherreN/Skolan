using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MacSnapHack
{
    /// <summary>
    ///     Holds Enums, Gotta move this later
    /// </summary>
    public static class TempEnumHolder
    {
        /// <summary>
        ///     Possible Status's of the Login Stage
        /// </summary>
        public enum LoginStatus
        {
            Success,
            InvalidCredentials,
            ServerError
        }
    }
}
