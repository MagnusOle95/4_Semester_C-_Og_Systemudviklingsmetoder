using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag7_Opgave3_udskrivTil_ExelArk
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Opretter køerne.
            //MessageQueue.Create(@".\Private$\BluffCityRequestQueueAIC");
            //MessageQueue.Create(@".\Private$\InvalidQueue");
            //MessageQueue.Create(@".\Private$\RequesterToExelAPI");

            //Sørens program.
            String Request = @".\Private$\BluffCityRequestQueueAIC";
            String Invalid = @".\Private$\InvalidQueue";
            MessageQueue RequesterToExelAPI = new MessageQueue(@".\Private$\RequesterToExelAPI");

            Flyselvskab_Requester SAS = new Flyselvskab_Requester(Request, "SAS249",RequesterToExelAPI);
            Flyselvskab_Requester SWA = new Flyselvskab_Requester(Request, "SWA1423",RequesterToExelAPI);
            Flyselvskab_Requester KLM = new Flyselvskab_Requester(Request, "KLM582", RequesterToExelAPI);
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
            SAS.send();


            ////Modtager repose fra AIC og sendes videre til Køen mellem requester og Exel. 
            SAS.ReceviedSync();

            //Opretter adapter og køre den. 
            Adapter_Og_ExelAPI adapterExel = new Adapter_Og_ExelAPI(RequesterToExelAPI);
            adapterExel.adaptFlyinformationToExel();

            Console.ReadLine();


        }
    }
}
