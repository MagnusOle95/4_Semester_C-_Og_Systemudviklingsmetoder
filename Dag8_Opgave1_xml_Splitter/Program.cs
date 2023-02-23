using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag8_Opgave1_xml_Splitter
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Opretter kør. 
            //MessageQueue.Create(@".\Private$\AirportCheckInOutput");
            //MessageQueue.Create(@".\Private$\LuggageQueue");
            //MessageQueue.Create(@".\Private$\PassengerQueue");


            //Forbinder til køerne. 
            MessageQueue messageQueue = new MessageQueue(@".\Private$\AirportCheckInOutput");
            MessageQueue Luggagequeue = new MessageQueue(@".\Private$\LuggageQueue");
            MessageQueue PassengerQueue = new MessageQueue(@".\Private$\PassengerQueue");



            //Læser og Sender xml fil til checkin Kø
            XElement CheckInFile = XElement.Load(@"CheckedInPassenger.xml");
            //Console.WriteLine(CheckInFile);
            string label = "Label";

            messageQueue.Send(CheckInFile, label);

            //opretter router. 
            Router_Splitter Router_Splitter = new Router_Splitter(messageQueue,Luggagequeue,PassengerQueue);

            Console.ReadLine();

        }
            
    }
}
