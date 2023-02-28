using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace Dag8_Opgave1_xml_Splitter
{
    internal class Router_Splitter
    {
        protected MessageQueue inQueue;
        protected MessageQueue passengerQueue;
        protected MessageQueue LuggageQueue;
        protected MessageQueue beginResequenz;
        public Router_Splitter(MessageQueue inQueue, MessageQueue luggageQueue, MessageQueue PassengerQueue, MessageQueue beginreseQuenzQueue) 
        {
            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inQueue.BeginReceive();
            string label = inQueue.Label;
            this.passengerQueue = PassengerQueue;
            this.LuggageQueue = luggageQueue;
            this.beginResequenz = beginreseQuenzQueue;
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
            var passenger = body.Element("Passenger");
            Console.WriteLine(passenger);
            passengerQueue.Send(passenger, passenger.Element("FirstName").Value);

            //Laver Variabler af luggage og sender til køen. 
            var luggages = body.Elements("Luggage");
            Console.WriteLine(luggages);
            
            foreach (var l in luggages)
            {
                LuggageQueue.Send(l, "" + passenger.Element("FirstName").Value);
            }

            //Fortæller resequenzer at den skal starte. 
            Message go = new Message();
            go.Label = "Go";
            go.Body = "Go";
            beginResequenz.Send(go);
            //Printer elemeter ud fra listen.
            
            string reservationsNummer = passenger.Element("ReservationNumber").Value;
            string firstName = passenger.Element("FirstName").Value;
            string lastName = passenger.Element("LastName").Value;
            Console.WriteLine(reservationsNummer);
            Console.WriteLine(firstName);
            Console.WriteLine(lastName);
            

            //Begynder ny læsning fra køen. 
            mq.BeginReceive();
        }
    }
}
