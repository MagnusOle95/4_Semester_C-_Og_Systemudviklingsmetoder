using System;
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
            //Finder antal i kø. 
            int Amount = inLuggage.GetAllMessages().Count();

            //Laver parent XElement
            XElement parentElement = new XElement("Information");

            //Henter og tilføjer passenger element til parent. 
            Message passenger = inPassenger.Receive();

            StreamReader pReader = new StreamReader(passenger.BodyStream);
            XElement pbody = XElement.Parse(pReader.ReadToEnd());

            parentElement.Add(pbody);

            ////Henter og tilføjer alle passengere luggage. 
            for (int i = 0; i < Amount ; i++)
            {
                Message luggage = inLuggage.Receive();

                StreamReader lReader = new StreamReader(luggage.BodyStream);
                XElement lBody = XElement.Parse(lReader.ReadToEnd());

                parentElement.Add(lBody);
            }

            outQueue.Send(parentElement);
           
        }

    }
}
