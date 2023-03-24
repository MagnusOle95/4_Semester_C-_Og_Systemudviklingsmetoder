using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag16_PatternLibary
{
    public class PublicSub1
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

            //foreach(MessageQueue outQueue in OutQueues)
            //{
            //    outQueue.Send(message);
            //}
            OutQueues[0].Send(message);
            OutQueues[1].Send(message);
            OutQueues[2].Send(message);


            mq.BeginReceive();
        }
    }
}
