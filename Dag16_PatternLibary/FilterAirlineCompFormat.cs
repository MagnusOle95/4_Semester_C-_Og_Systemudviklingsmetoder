using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag16_PatternLibary
{
    public class FilterAirlineCompFormat
    {
        protected MessageQueue InQueue;
        protected MessageQueue OutQueue;

        public FilterAirlineCompFormat(MessageQueue inQueue, MessageQueue outQueue)
        {
            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inQueue.BeginReceive();
            this.InQueue = inQueue;
            this.OutQueue = outQueue;
        }

        private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            //Henter fra køen. 
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);

            //Parse stringen fra køen til en xml fil igen. 
            StreamReader reader = new StreamReader(message.BodyStream);
            XElement body = XElement.Parse(reader.ReadToEnd());

            //Fjerne de ting der ikke skal sendes med videre. 
            XElement sun = body.Element("sun");
            sun.Remove();
            XElement coordinates = body.Element("coord");
            coordinates.Remove();
            XElement humidity = body.Element("humidity");
            humidity.Remove();
            XElement pressure = body.Element("pressure");
            pressure.Remove();
            XElement wind = body.Element("wind");
            wind.Remove();
            XElement visibility = body.Element("visibility");
            visibility.Remove();

            //Udskriver så de kan ses og sender ud i outQueue.  
            Console.WriteLine("ATC Format !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(body);

            OutQueue.Send(body);

            mq.BeginReceive();
        }
    }
}
