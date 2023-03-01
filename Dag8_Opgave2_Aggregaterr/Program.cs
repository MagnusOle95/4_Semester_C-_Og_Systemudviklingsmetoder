using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag8_Opgave2_Aggregaterr
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opretter kør.
            //MessageQueue.Create(@".\Private$\PassengerQueue");
            //MessageQueue.Create(@".\Private$\ResequenzerOut");
            //MessageQueue.Create(@".\Private$\AgregaterOut");



            //Forbinder til køerne. 
            MessageQueue PassengerQueue = new MessageQueue(@".\Private$\PassengerQueue");
            MessageQueue ResequenzerQueue = new MessageQueue(@".\Private$\ResequenzerOut");
            MessageQueue AgregaterOutQueue = new MessageQueue(@".\Private$\AgregaterOut");

            //opretter aggregater
            Agregator aggregater = new Agregator(PassengerQueue, ResequenzerQueue, AgregaterOutQueue);

            aggregater.agregateMessages();

            Console.ReadLine();

        }


    }
    
}
