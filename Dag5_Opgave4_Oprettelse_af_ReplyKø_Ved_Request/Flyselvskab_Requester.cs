using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag5_Opgave4_Oprettelse_af_ReplyKø_Ved_Request
{
    internal class Flyselvskab_Requester
    {
        private MessageQueue requestQueue;
        private MessageQueue replyQueue;
        private String flyid;

        public Flyselvskab_Requester(String requestQueueName, String flyId)
        {
            requestQueue = new MessageQueue(requestQueueName);
            this.flyid = flyId;
        }

        public void send()
        {
            replyQueue = MessageQueue.Create(@".\Private$\" + flyid + "Kø");

            Message requestMessage= new Message();

            requestMessage.Body = flyid;
            requestMessage.Label = flyid.Substring(0, 3);

            requestMessage.ResponseQueue= replyQueue;
            requestQueue.Send(requestMessage);
        }

        public Message ReceviedSync()
        {
            Message ReceviedMessage = replyQueue.Receive();
            MessageQueue.Delete(@".\Private$\" + flyid + "Kø");
            ReceviedMessage.Formatter = new XmlMessageFormatter(new Type[] { typeof(Flyinformation) });
            return ReceviedMessage;
        }
    }
}
