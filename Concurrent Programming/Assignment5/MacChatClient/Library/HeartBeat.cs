using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// This method represents a heartbeat. 
    /// A heartbeat contains a list of users and a list of lobbymessages.
    /// </summary>
    [Serializable]
    public class HeartBeat
    {
        private List<LobbyMessage> lobbyMessages;
        private List<User> userList;

        public HeartBeat()
        {

        }
        public HeartBeat(List<LobbyMessage> piLobbyList)
        {
            this.lobbyMessages = piLobbyList;
        }
        public HeartBeat(List<User> piUserList)
        {
            this.userList = piUserList;
        }
        public HeartBeat(List<User> piUserList, List<LobbyMessage> piLobbyList)
        {
            this.userList = piUserList;
            this.lobbyMessages = piLobbyList;
        }
        /// <summary>
        /// A property to set the lobbymessagelist.
        /// </summary>
        public List<LobbyMessage> LobbyMessages
        {
            get { return lobbyMessages; }
            set { lobbyMessages = value; }
        }
        /// <summary>
        /// A property to set the userlist.
        /// </summary>
        public List<User> UserList
        {
            get { return userList; }
            set { userList = value; }
        }
    }
}
