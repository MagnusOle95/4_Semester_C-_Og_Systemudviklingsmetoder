using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag8_Opgave1_xml_Splitter
{
    internal class Resequenzer
    {
        protected MessageQueue inQueue;
        protected MessageQueue outQueue;
        protected MessageQueue BeginResequenzQueue;

        public Resequenzer(MessageQueue inQueue, MessageQueue outQueue, MessageQueue BeginResequenzQueue) 
        {
            this.inQueue = inQueue;
            this.outQueue = outQueue;
            this.BeginResequenzQueue = BeginResequenzQueue;
            BeginResequenzQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            BeginResequenzQueue.BeginReceive();
        }

        private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            //Afventer resequenzer køen. 
            MessageQueue mq = (MessageQueue)source;
            //Message message = mq.EndReceive(asyncResult.AsyncResult);
            send();
            mq.BeginReceive();
        }

        private void send()
        {
            //Finder antalbeskeder i køen og henter dem ud i et array. 
            int antalBeskeder = inQueue.GetAllMessages().Count();
            Console.WriteLine(antalBeskeder);

            //Her putter jeg beskederne ind i den rigtige rækkefølge.  
            Message[] resequenzedList = new Message[antalBeskeder];
            for(int i = 0; i < antalBeskeder; i++)
            {
                Message m = inQueue.Receive();

                StreamReader reader = new StreamReader(m.BodyStream);
                XElement mbody = XElement.Parse(reader.ReadToEnd());

                int index = int.Parse(mbody.Element("Identification").Value) - 1;

                //Her vil det være smart at tjekke om dette index på arrayet er tomt ellers smid det i invalid queue. ----------------------------------------
                resequenzedList[index] = m;
            }

            //Sender ud til køen. 
            for (int i = 0; i < resequenzedList.Length; i++) 
            {
                outQueue.Send(resequenzedList[i]);
            }


        }
    }
}
