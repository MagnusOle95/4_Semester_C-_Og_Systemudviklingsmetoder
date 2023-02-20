using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag7_Opgave3_udskrivTil_ExelArk
{
    internal class Flyselvskab_Requester
    {
        private MessageQueue requestQueue;
        private MessageQueue replyQueue;
        private String flyid;
        private MessageQueue RequesterToExelAPIQueue;

        public Flyselvskab_Requester(String requestQueueName, String flyId, MessageQueue RequesterToExelAPIQueue)
        {
            requestQueue = new MessageQueue(requestQueueName);
            this.flyid = flyId;
            this.RequesterToExelAPIQueue = RequesterToExelAPIQueue;
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

        public void ReceviedSync()
        {
            Message ReceviedMessage = replyQueue.Receive();
            MessageQueue.Delete(@".\Private$\" + flyid + "Kø");
            RequesterToExelAPIQueue.Send(ReceviedMessage);
        }
    }
}
