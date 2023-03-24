using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag16_PatternLibary
{
    public class FilterAICFormat
    {
        protected MessageQueue InQueue;
        protected MessageQueue OutQueue;

        public FilterAICFormat(MessageQueue inQueue, MessageQueue outQueue)
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

            //Fimder værdierne af sunset og sunrise. 
            string sunsetString = body.Element("sun").Attribute("rise").Value; ;
            var sunsetXElement = XElement.Parse("<sunset>" + sunsetString + "</sunset>");

            string sunriseString = body.Element("sun").Attribute("rise").Value;
            var sunriseXElement = XElement.Parse("<sunrise>" + sunriseString + "</sunrise>");

            //tilføjer sunrise og sunset til body. 
            body.Add(sunsetXElement);
            body.Add(sunriseXElement);

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
            XElement clouds = body.Element("clouds");
            clouds.Remove();
            XElement visibility = body.Element("visibility");
            visibility.Remove();
        
            //Udskriver formattet.
            Console.WriteLine("AIC Format !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(body);
           
            OutQueue.Send(body);

            mq.BeginReceive();
        }
    }
}
