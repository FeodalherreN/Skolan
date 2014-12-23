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
    /// This class represents a privatemessage.
    /// </summary>
    [Serializable]
    public class PrivateMessage
    {
        private string ivMessage; //The message itself.
        private DateTime ivTime; //What time
        private User ivSender; //The sender
        private User ivReciever; //The reciever

        public PrivateMessage()
        {

        }
        public PrivateMessage(string piMessage, DateTime piTime, User piSender, User piReciever)
        {
            this.ivMessage = piMessage;
            this.ivTime = piTime;
            this.ivSender = piSender;
            this.ivReciever = piReciever;
        }

        /// <summary>
        /// A property for the message.
        /// </summary>
        public string MessageText
        {
            get { return ivMessage; }
            set { ivMessage = value; }
        }

        /// <summary>
        /// A property for the time sent.
        /// </summary>
        public DateTime Time
        {
            get { return ivTime; }
            set { ivTime = value; }
        }
        
        /// <summary>
        /// A property for the senderuser.
        /// </summary>
        public User Sender
        {
            get { return ivSender; }
            set { ivSender = value; }
        }

        /// <summary>
        /// A property for the reciver user.
        /// </summary>
        public User Reciever
        {
            get { return ivReciever; }
            set { ivReciever = value; }
        }
    }
}
