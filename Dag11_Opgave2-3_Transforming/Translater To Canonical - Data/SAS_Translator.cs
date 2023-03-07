using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Net.Security;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag11_Opgave2_3_Transforming.Translater_To_Canonical___Data
{
    internal class SAS_Translator
    {
        protected MessageQueue inQueue;
        protected MessageQueue outQueue;
        private Dictionary<string, int> monthlist = new Dictionary<string, int>();

        public SAS_Translator(MessageQueue inQueue ,MessageQueue outQueue)
        {
            monthlist.Add("Januar",1);
            monthlist.Add("Februar",2);
            monthlist.Add("Marts",3);
            monthlist.Add("April",4);
            monthlist.Add("Maj",5);
            monthlist.Add("Juni",6);
            monthlist.Add("Juli",7);
            monthlist.Add("August",8);
            monthlist.Add("September",9);
            monthlist.Add("Oktober",10);
            monthlist.Add("November",11);
            monthlist.Add("December",12);

            this.inQueue = inQueue;
            this.outQueue = outQueue;
            inQueue.ReceiveCompleted += new ReceiveCompletedEventHandler(OnMessage);
            inQueue.BeginReceive();
        }

        private void OnMessage(Object source, ReceiveCompletedEventArgs asyncResult)
        {
            //Afventer resequenzer køen. 
            MessageQueue mq = (MessageQueue)source;
            Message message = mq.EndReceive(asyncResult.AsyncResult);

            //Translater 

            //string ms = message.Body.ToString();
            StreamReader Reader = new StreamReader(message.BodyStream);
            XElement body = XElement.Parse(Reader.ReadToEnd());

            //Finder reservations nummer på person.
            string airlineName = body.Element("Airline").Value;
            string flightNr = body.Element("FlightNo").Value;
            string destinationAirport = body.Element("Destination").Value;
            string depatureAirport = body.Element("Origin").Value;
            string statusAD = body.Element("ArrivalDeparture").Value;
            string dato = body.Element("Dato").Value;
            string tidspunkt = body.Element("Tidspunkt").Value;


            ////Laver en datetime ud fra dato og tidspunkt. 
            String[] datoA = dato.Split(' ');
            int year = int.Parse(datoA[2]);
            int month = monthlist[datoA[1]];
            int day = int.Parse(datoA[0].Substring(0, datoA[0].Length - 1));

            string[] tidspunktA = tidspunkt.Split(':');
            int hour = int.Parse(tidspunktA[0]);
            int minuts = int.Parse(tidspunktA[1]); ;

            Console.WriteLine(year + " " + month + " " + day + " " + hour + " " + minuts);
            DateTime datetime = new DateTime(year, month, day, hour, minuts, 0);

            //Opretter CanocialData Fly og sender det ud. 
            Airplane_canonicalData cdFi = new Airplane_canonicalData(airlineName,flightNr,depatureAirport,destinationAirport,statusAD,datetime);

            Console.WriteLine(cdFi.ToString());

            outQueue.Send(cdFi);



            mq.BeginReceive();
        }

  
    }
}
