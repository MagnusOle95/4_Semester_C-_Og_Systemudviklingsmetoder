using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag7_Opgave1_Set_Time_To_Be_Recived
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Opretter køerne.
            //MessageQueue.Create(@".\Private$\TimeToReciveQueue");

            //Forbinder til køen. 
            MessageQueue queue = new MessageQueue(@".\Private$\TimeToReciveQueue");

            //Opretter message og sætter tid inden den skal slettes. 
            Message besked = new Message();
            besked.Label= "A";
            besked.Body = "B";
            besked.TimeToBeReceived = TimeSpan.FromSeconds(20);

            //Afsender message. 
            queue.Send(besked);



        }
    }
}
