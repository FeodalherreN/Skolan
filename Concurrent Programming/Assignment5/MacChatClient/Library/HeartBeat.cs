using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
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
        public List<LobbyMessage> LobbyMessages
        {
            get { return lobbyMessages; }
            set { lobbyMessages = value; }
        }
        public List<User> UserList
        {
            get { return userList; }
            set { userList = value; }
        }
    }
}
