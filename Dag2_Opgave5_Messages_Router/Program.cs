using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Opgave5_6_Message_router
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Opretter kør. 
            //MessageQueue.Create(@".\Private$\inQueue");
            //MessageQueue.Create(@".\Private$\QueueSAS");
            //MessageQueue.Create(@".\Private$\QueueSWA");

            //Opretter forbindelse til kør og laver router. 
            MessageQueue inmessageQueue = new MessageQueue(@".\Private$\inQueue");
            MessageQueue messageQueueSAS = new MessageQueue(@".\Private$\QueueSAS");
            MessageQueue messageQueueSWA = new MessageQueue(@".\Private$\QueueSWA");
            SimpleRouter simpelrouter = new SimpleRouter(inmessageQueue, messageQueueSAS, messageQueueSWA);

            //Oprette besked til router.
            inmessageQueue.Send("Flyinformation", "SAS");

            ////Henter besked fra SAS
            //Message mSas = messageQueueSAS.Receive();
            //mSas.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
            //Console.WriteLine(mSas.Label + ": " + mSas.Body);

            ////Henter beskeder fra South West Airlines. 
            //Message mSwa = messageQueueSWA.Receive();
            //mSwa.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
            //Console.WriteLine(mSwa.Label + ": " + mSwa.Body);

            Console.ReadLine();
        }
    }
}
