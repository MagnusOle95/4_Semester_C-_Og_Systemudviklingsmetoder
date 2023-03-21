using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag15_EventDrivenConsumer2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opretter kør. 
            //MessageQueue.Create(@".\Private$\CheckInEmployee");

            //Forbinder til køerne. 
            MessageQueue messageQueue = new MessageQueue(@".\Private$\CheckInEmployee");

            //Opretter eventdrivenCostumer
            EventDrivenCostumer evtDriCos = new EventDrivenCostumer(messageQueue);
            Console.ReadKey();
        }
    }
}
