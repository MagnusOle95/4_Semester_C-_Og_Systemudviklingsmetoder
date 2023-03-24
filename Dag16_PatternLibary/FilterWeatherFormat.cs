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
    public class FilterWeatherFormat
    {
        protected MessageQueue InQueue;
        protected MessageQueue OutQueue;

        public FilterWeatherFormat(MessageQueue inQueue, MessageQueue outQueue)
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

            //Finder reservations nummer på person.
            string nameOfCityString = body.Element("city").Attribute("name").Value;
            var nameOfCityXElement = XElement.Parse("<nameOfCity>" + nameOfCityString + "</nameOfCity>");
            var coordinates = body.Element("city").Element("coord");
            var country = body.Element("city").Element("country");
            var temperature = body.Element("temperature");
            var humidity = body.Element("humidity");
            var pressure = body.Element("pressure");
            var wind = body.Element("wind");
            var clouds = body.Element("clouds");
            var visibility = body.Element("visibility");
            var sun = body.Element("city").Element("sun"); ;

            // Parse the XML response into an XmlDocument
            XElement xmlDoc = new XElement("Curent_wheather_information");
            xmlDoc.Add(nameOfCityXElement);
            xmlDoc.Add(coordinates);
            xmlDoc.Add(country);
            xmlDoc.Add(temperature);
            xmlDoc.Add(humidity);
            xmlDoc.Add(pressure);
            xmlDoc.Add(wind);
            xmlDoc.Add(clouds);
            xmlDoc.Add(visibility);
            xmlDoc.Add(sun);

            //Udskriver så de kan ses. 
            Console.WriteLine("Weather Format !!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine(xmlDoc);

            OutQueue.Send(xmlDoc);

            mq.BeginReceive();
        }

    }
}
