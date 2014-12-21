using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    [Serializable]
    public class Message
    {
        private string ivMessage;
        private DateTime ivTime;
        private User ivSender;
        private User ivReciever;

        public Message()
        {

        }
        public Message(string piMessage, DateTime piTime, User piSender, User piReciever)
        {
            this.ivMessage = piMessage;
            this.ivTime = piTime;
            this.ivSender = piSender;
            this.ivReciever = piReciever;
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
        public User Reciever
        {
            get { return ivReciever; }
            set { ivReciever = value; }
        }
    }
}
