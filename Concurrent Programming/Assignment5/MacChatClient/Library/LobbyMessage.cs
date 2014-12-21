using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
    public class LobbyMessage
    {
        private string ivMessage;
        private DateTime ivTime;
        private User ivSender;

        public LobbyMessage()
        {

        }
        public LobbyMessage(string piMessage, DateTime piTime, User piSender)
        {
            this.ivMessage = piMessage;
            this.ivTime = piTime;
            this.ivSender = piSender;
        }

        public string MessageText
        {
            get { return ivMessage; }
            set { ivMessage = value; }
        }

        public DateTime Time
        {
            get { return ivTime; }
            set { ivTime = value; }
        }
        public User Sender
        {
            get { return ivSender; }
            set { ivSender = value; }
        }
    }
}
