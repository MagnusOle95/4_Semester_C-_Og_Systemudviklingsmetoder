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
        private Message[] beskederInd;

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
            Message[] beskeder = new Message[antalBeskeder];

            for (int i = 0; i< antalBeskeder; i++)
            {
                beskeder[i] = inQueue.Receive();
            }

            //Her vil jeg resequenze beskederne. 
            Message[] resequenzedList = new Message[antalBeskeder + 1];
            foreach (Message m in beskeder) 
            {
                StreamReader reader = new StreamReader(m.BodyStream);
                XElement mbody = XElement.Parse(reader.ReadToEnd());

                int index = int.Parse(mbody.Element("Identification").Value);

                resequenzedList[index] = m;
            }

            //Sender ud til køen. 
            for(int i = 1; i < resequenzedList.Length; i++) 
            {
                outQueue.Send(resequenzedList[i]);
            }



            //foreach (Message mInd in beskederInd) 
            //{
            //    dic.Add(int.Parse(mInd.Label), mInd);
            //}

            //for (int i = 0; i <= beskederInd.Length;i++)
            //{
            //    var m= dic[i+1];
            //    outQueue.Send(m);
            //}

        }
    }
}
