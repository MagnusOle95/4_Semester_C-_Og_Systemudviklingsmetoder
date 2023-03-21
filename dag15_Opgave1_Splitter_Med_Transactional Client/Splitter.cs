using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dag15_Opgave1_Splitter_Med_Transactional_Client
{
    internal class Splitter
    {
        protected MessageQueue inQueue;
        protected MessageQueue passengerQueue;
        protected MessageQueue LuggageQueue;
        public Splitter(MessageQueue inQueue, MessageQueue luggageQueue, MessageQueue PassengerQueue)
        {
            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inQueue.BeginReceive();
            string label = inQueue.Label;
            this.passengerQueue = PassengerQueue;
            this.LuggageQueue = luggageQueue;
        }

        private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            //Henter fra køen. 
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);

            //Parse stringen fra køen til en xml fil igen. 
            StreamReader reader = new StreamReader(message.BodyStream);
            XElement body = XElement.Parse(reader.ReadToEnd());

            //Opretter en transaktion og stater den.  
            MessageQueueTransaction msgTx = new MessageQueueTransaction();
            msgTx.Begin();
            try
            {
                //Laver variabel af Passenger, og sender til kø. 
                var passenger = body.Element("Passenger");
                Console.WriteLine(passenger);
                passengerQueue.Send(passenger, passenger.Element("FirstName").Value,msgTx);

                //Funktion til at teste, om transaktionen bliver stoppet. 
                //Environment.Exit(1);

                //Laver Variabler af luggage og sender til køen. 
                var luggages = body.Elements("Luggage");
                Console.WriteLine(luggages);

                foreach (var l in luggages)
                {
                    LuggageQueue.Send(l, "" + passenger.Element("FirstName").Value,msgTx);
                }
                msgTx.Commit();
            }
            catch
            {
                msgTx.Abort();
            }
            finally 
            {
                passengerQueue.Close();
                LuggageQueue.Close();
            }

            //Begynder ny læsning fra køen. 
            mq.BeginReceive();
        }
    }
}
