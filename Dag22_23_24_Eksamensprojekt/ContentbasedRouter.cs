using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag22_23_24_Eksamensprojekt
{
    internal class ContentbasedRouter
    {
        protected MessageQueue inQueue;
        protected MessageQueue outQueue_LMS;
        protected MessageQueue outQueue_PAYS;
        public ContentbasedRouter(MessageQueue inQueue, MessageQueue outQueue_LMS, MessageQueue outQueue_PAYS)
        {
            this.inQueue = inQueue;
            this.outQueue_LMS = outQueue_LMS;
            this.outQueue_PAYS = outQueue_PAYS;
            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inQueue.BeginReceive();
        }
        private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);

            //Parse stringen fra køen til en xml fil igen. 
            StreamReader reader = new StreamReader(message.BodyStream);
            XElement body = XElement.Parse(reader.ReadToEnd());


            //Henter Systemtypen fra XML beskeden ved hjælp af LINQ.
            string systemType = body.Element("SystemType").Value;

            //Tjekker beskedens systemtype. og sender til kø. 
            if (systemType == "CheckIn")
                outQueue_LMS.Send(message);
            else if (systemType == "Payment")
                outQueue_PAYS.Send(message);

            mq.BeginReceive();
        }
        
    }
}
