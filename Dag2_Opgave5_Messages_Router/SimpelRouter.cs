using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Opgave5_6_Message_router
{
    class SimpleRouter
    {
        protected MessageQueue inQueue;
        protected MessageQueue outQueue1;
        protected MessageQueue outQueue2;
        public SimpleRouter(MessageQueue inQueue, MessageQueue outQueue1, MessageQueue outQueue2)
        {
            this.inQueue = inQueue;
            this.outQueue1 = outQueue1;
            this.outQueue2 = outQueue2;
            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inQueue.BeginReceive();
        }
        private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);

            if (message.Label == "SAS")
                outQueue1.Send(message);
            else if (message.Label == "SWA")
                outQueue2.Send(message);
            mq.BeginReceive();
        }
        //protected bool toggle = false;
        //protected bool IsConditionFulfilled()
        //{
        //    toggle = !toggle;
        //    return toggle;
        //}
    }
}
