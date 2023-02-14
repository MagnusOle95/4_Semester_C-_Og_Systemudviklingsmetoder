using Dag4_Opgave4_Opg3_Med_Message_Filtering_Pattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag5_Opgave1_Request_reciver
{
    internal class Flyselvskab_Requester
    {
        private MessageQueue requestQueue;
        private MessageQueue replyQueue;
        private String flyid;

        public Flyselvskab_Requester(String requestQueueName, String replyQueueName, String flyId)
        {
            requestQueue = new MessageQueue(requestQueueName);
            replyQueue = new MessageQueue(replyQueueName);
            this.flyid = flyId;
            replyQueue.MessageReadPropertyFilter.SetAll();
            ((XmlMessageFormatter)replyQueue.Formatter).TargetTypeNames = new string[] { "System.String,mscorlib" };

        }

        public void send()
        {
            Message requestMessage= new Message();

            requestMessage.Body = flyid;
            requestMessage.Label = flyid.Substring(0, 3);

            requestMessage.ResponseQueue= replyQueue;
            requestQueue.Send(requestMessage);
        }

        public void ReceviedSync()
        {
            Message replyMessage = replyQueue.Receive();
        }
    }
}
