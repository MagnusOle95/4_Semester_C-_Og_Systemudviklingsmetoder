using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag8_Opgave2_Aggregaterr
{
    internal class Agregator
    {
        protected MessageQueue inPassenger;
        protected MessageQueue inLuggage;
        protected MessageQueue outQueue;


        public Agregator(MessageQueue indqueuePassenger, MessageQueue indQueueLuggage, MessageQueue outqueue) 
        {
            this.inPassenger = indqueuePassenger;
            this.inLuggage = indQueueLuggage;
            this.outQueue = outqueue;
        }

        public void agregateMessages()
        {
            //Laver parent XElement
            XElement parentElement = new XElement("Information");

            //Henter og tilføjer passenger element til parent. 
            Message passenger = inPassenger.Receive();

            StreamReader pReader = new StreamReader(passenger.BodyStream);
            XElement pbody = XElement.Parse(pReader.ReadToEnd());

            //Finder reservations nummer på person.
            string resNr = pbody.Element("ReservationNumber").Value;

            //Tilføjer Passagere til XML parent. 
            parentElement.Add(pbody);

            ////Henter og tilføjer alle passengere luggage. 

            Message[] luggageQ = inLuggage.GetAllMessages();


            foreach (Message l in luggageQ) 
            { 
                StreamReader lReader = new StreamReader(l.BodyStream);
                XElement lBody = XElement.Parse(lReader.ReadToEnd());

                if (resNr.Equals(lBody.Element("Id").Value))
                {
                    parentElement.Add(lBody);
                    Message tempL = inLuggage.Receive();
                    tempL.Dispose(); //Fjerner alt om temlp i Ram. 
                }
                else
                {
                    break;
                }
            }
            outQueue.Send(parentElement); 
        }
    }
}
