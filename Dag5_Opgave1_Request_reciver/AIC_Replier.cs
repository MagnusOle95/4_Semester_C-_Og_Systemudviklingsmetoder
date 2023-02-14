using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Dag5_Opgave1_Request_reciver
{
    internal class AIC_Replier
    {
        private MessageQueue invalidQueue;

        public AIC_Replier (String requestQueueName, String InvalidQueueName)
        {
            MessageQueue requestQueue = new MessageQueue (requestQueueName);
            invalidQueue = new MessageQueue (InvalidQueueName);

            requestQueue.MessageReadPropertyFilter.SetAll();
            ((XmlMessageFormatter)requestQueue.Formatter).TargetTypeNames = new string[] { "System.String,mscorlib" };

            try
            {
                requestQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnReceivedCompleted);
                requestQueue.BeginReceive();
            }
            catch (Exception) 
            {
                System.Diagnostics.Debug.WriteLine("Noget er galt");
            }
        }

        public void OnReceivedCompleted(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue requestQueue = (MessageQueue)source;
            Message requestMessage = requestQueue.EndReceive(asyncResult.AsyncResult);

            try
            {
                string contents = requestMessage.Body.ToString();
                MessageQueue replyQueue = requestMessage.ResponseQueue;
                string label = requestMessage.Label;

                switch (label)
                {
                    case "SAS":
                        contents = "13:45";
                        break;
                    case "KLM":
                        contents = "14:25";
                        break;
                    case "SWA":
                        contents = "15:40";
                        break;
                }
                Message replymessage = new Message();
                replymessage.Body= contents;
                replymessage.CorrelationId = requestMessage.Id;
                replyQueue.Send(replymessage);

            }
            catch(Exception)
            {
                requestMessage.CorrelationId = requestMessage.Id;
                invalidQueue.Send(requestMessage);
            }
            requestQueue.BeginReceive();
        }
    }
}
