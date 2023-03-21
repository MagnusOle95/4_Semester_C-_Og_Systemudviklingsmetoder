using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace dag15_Opgave1_Splitter_Med_Transactional_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Opretter kør. 
            //MessageQueue.Create(@".\Private$\AirportCheckInOutput");
            //MessageQueue.Create(@".\Private$\LuggageQueue",true);
            //MessageQueue.Create(@".\Private$\PassengerQueue",true);

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
            Splitter s = new Splitter(messageQueue, Luggagequeue, PassengerQueue);
           
            Console.ReadLine();

        }
    }
}
