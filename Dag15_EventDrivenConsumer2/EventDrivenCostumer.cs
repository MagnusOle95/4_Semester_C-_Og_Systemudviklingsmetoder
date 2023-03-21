using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag15_EventDrivenConsumer2
{
    internal class EventDrivenCostumer
    {
        protected MessageQueue inQueue;

        public EventDrivenCostumer(MessageQueue inQueue)
        {
            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inQueue.BeginReceive();
        }

        private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            //Henter fra køen. 
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);

            //Parse stringen fra køen til en xml fil igen. 
            StreamReader reader = new StreamReader(message.BodyStream);
            XElement body = XElement.Parse(reader.ReadToEnd());

            //Laver variabel af Passenger, og sender til kø. 
            var information = body.Elements();

            //Løber listen  igennem og udskriver den. 
            string s = "";

            //string builder 
            foreach(var xe in information)
            {
                s += xe.Name + ": " + xe.Value + ", ";
            }
            Console.WriteLine(s);

            //Begynder ny læsning fra køen. 
            mq.BeginReceive();
        }
    }
}
