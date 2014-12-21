using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace MacChatServer
{
    [Serializable]
    public class Message : ISerializable
    {
        private string ivMessage;
        private DateTime ivTime;
        private User ivSender;
        private User ivReciever;

        public Message(string piMessage, DateTime piTime, User piSender, User piReciever)
        {
            this.ivMessage = piMessage;
            this.ivTime = piTime;
            this.ivSender = piSender;
            this.ivReciever = piReciever;
        }
        protected Message(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            ivMessage = (string)info.GetValue("Message ", typeof(string));
            ivTime = (DateTime)info.GetValue("Time", typeof(DateTime));
            ivSender = (User)info.GetValue("Sender", typeof(User));
            ivReciever = (User)info.GetValue("Reciever", typeof(User));
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
        [SecurityPermissionAttribute(SecurityAction.LinkDemand,
     Flags = SecurityPermissionFlag.SerializationFormatter)]
        void ISerializable.GetObjectData(SerializationInfo info, StreamingContext context)
        {
            if (info == null)
                throw new System.ArgumentNullException("info");
            info.AddValue("Message", ivMessage);
            info.AddValue("Time", ivTime);
            info.AddValue("Sender", ivSender);
            info.AddValue("Reciever", ivReciever);
        }
    }
}
