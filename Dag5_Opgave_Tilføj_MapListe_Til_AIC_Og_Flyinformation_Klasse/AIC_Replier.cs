using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Diagnostics;

namespace Dag5_Opgave1_Tilføj_MapListe_Til_AIC_Og_Flyinformation_Klasse
{
    internal class AIC_Replier
    {
        private MessageQueue invalidQueue;
        private Dictionary<string, Flyinformation> listeMedflyinformation = new Dictionary<string, Flyinformation>();
        
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
                
                Message replymessage = new Message();
                replymessage.Label= contents;
                replymessage.Body = listeMedflyinformation[contents];
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

        public void addFinfoToFlyinformationList(string flyidKey, Flyinformation flyinfo)
        {
            this.listeMedflyinformation.Add(flyidKey, flyinfo);
        }
    }
}
