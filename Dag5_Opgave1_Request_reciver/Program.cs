using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag5_Opgave1_Request_reciver
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Opretter køerne.
            //MessageQueue.Create(@".\Private$\BluffCityRequestQueueAIC");
            //MessageQueue.Create(@".\Private$\BluffCityReplyQueueSAS");
            //MessageQueue.Create(@".\Private$\BluffCityReplyQueueSW");
            //MessageQueue.Create(@".\Private$\BluffCityReplyQueueKLM");
            //MessageQueue.Create(@".\Private$\InvalidQueue");

            //Sørens program.
            String Request = @".\Private$\BluffCityRequestQueueAIC";
            String ReplySAS = @".\Private$\BluffCityReplyQueueSAS";
            String ReplySW = @".\Private$\BluffCityReplyQueueSW";
            String ReplyKLM = @".\Private$\BluffCityReplyQueueKLM";
            String Invalid = @".\Private$\InvalidQueue";

            Flyselvskab_Requester SAS = new Flyselvskab_Requester(Request, ReplySAS, "SAS249");
            Flyselvskab_Requester SWA = new Flyselvskab_Requester(Request, ReplySW, "SWA1423");
            Flyselvskab_Requester KLM = new Flyselvskab_Requester(Request, ReplyKLM, "KLM582");
            AIC_Replier AIC = new AIC_Replier(Request, Invalid);

            ////Sender request, om fly. 
            //SAS.send();
            //KLM.send();
            //SWA.send();

            ////Modtager repose fra AIC reponse kør. 
            //SAS.ReceviedSync();
            //KLM.ReceviedSync();
            //SWA.ReceviedSync();

            Console.ReadLine();


        }
    }
}
