using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    /// <summary>
    /// This class represents a lobbymessage.
    /// </summary>
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
        
        /// <summary>
        /// Property for the message.
        /// </summary>
        public string MessageText
        {
            get { return ivMessage; }
            set { ivMessage = value; }
        }

        /// <summary>
        /// Property for the time sent.
        /// </summary>
        public DateTime Time
        {
            get { return ivTime; }
            set { ivTime = value; }
        }

        /// <summary>
        /// Property for the sender.
        /// </summary>
        public User Sender
        {
            get { return ivSender; }
            set { ivSender = value; }
        }
    }
}
