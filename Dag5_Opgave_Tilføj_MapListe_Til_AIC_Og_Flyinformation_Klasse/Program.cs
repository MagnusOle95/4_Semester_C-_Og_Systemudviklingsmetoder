using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag5_Opgave1_Tilføj_MapListe_Til_AIC_Og_Flyinformation_Klasse
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

            //Opretter flyinformation. 
            DateTime arrival = new DateTime(1993, 01, 01);
            Flyinformation fSAS = new Flyinformation(arrival, "SAS249");

            DateTime arrival2 = new DateTime(2022, 09, 22);
            Flyinformation fKLM = new Flyinformation(arrival2, "KLM582");

            DateTime arrival3 = new DateTime(2023, 04, 23);
            Flyinformation fSWA = new Flyinformation(arrival3, "SWA1423");

            //Tilføjer flyinformation til AIC's flyinformations liste. 
            AIC.addFinfoToFlyinformationList(fSAS.FlyId, fSAS);
            AIC.addFinfoToFlyinformationList(fKLM.FlyId, fKLM);
            AIC.addFinfoToFlyinformationList(fSWA.FlyId, fSWA);

            ////Sender request, om fly. 
            //SAS.send();
            //KLM.send();
            //SWA.send();

            ////Modtager repose fra AIC reponse kør. 
            Console.WriteLine(SAS.ReceviedSync().ToString());
            //KLM.ReceviedSync();
            //SWA.ReceviedSync();

            Console.ReadLine();


        }
    }
}
