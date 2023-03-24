using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag16_Patterns_Net_Framework
{
    internal class PublicSub1
    {
        protected MessageQueue Inqueue;
        protected List<MessageQueue> OutQueues;
        public PublicSub1(MessageQueue inqueue, List<MessageQueue> outQueues)
        {
            this.Inqueue = inqueue;
            this.OutQueues = outQueues;
            inqueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inqueue.BeginReceive();
        }
        private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult); //let me confus u

            string messageLabelAsString = (string)message.Label.Substring(0, 3);
            Console.WriteLine(messageLabelAsString);

            if (messageLabelAsString == "SAS")
            {
                Router_To_SAS.Send(message);
            }
            else if (messageLabelAsString == "KLM")
            {
                Router_To_KLM.Send(message);
            }
            else if (messageLabelAsString == "SWA")
            {
                Router_To_SWA.Send(message);
            }
            mq.BeginReceive();
        }
    }
}

