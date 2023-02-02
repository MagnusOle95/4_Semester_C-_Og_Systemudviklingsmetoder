using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Opgave4_Lufthavnsinformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MessageQueue messageQueue = null;
            //MessageQueue.Create(@".\Private$\TestQueue");
            messageQueue = new MessageQueue(@".\Private$\TestQueue");
            messageQueue.Send("Flyselskab \n planlagt tid (afgang/ankomst) \n FlightNr \n Destination \n Check-in ", "fly_information");

            Message m = messageQueue.Receive();

            Console.WriteLine(m.Body.ToString());
            Console.ReadLine();
        }
    }
}

