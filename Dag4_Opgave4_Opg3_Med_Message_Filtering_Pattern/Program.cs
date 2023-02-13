using Dag4_Opgave3_Subscriber_Channel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace Dag4_Opgave4_Opg3_Med_Message_Filtering_Pattern
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Opretter Kør
            //MessageQueue.Create(@".\Private$\AirportInformation_To_Router");
            //MessageQueue.Create(@".\Private$\Router_To_SAS");
            //MessageQueue.Create(@".\Private$\Router_To_KLM");
            //MessageQueue.Create(@".\Private$\Router_To_SWA");


            //Opretter Forbindelse til kør.
            MessageQueue AirportInformation_To_Router = new MessageQueue(@".\Private$\AirportInformation_To_Router");
            MessageQueue Router_To_SAS = new MessageQueue(@".\Private$\Router_To_SAS");
            MessageQueue Router_To_KLM = new MessageQueue(@".\Private$\Router_To_KLM");
            MessageQueue Router_To_SWA = new MessageQueue(@".\Private$\Router_To_SWA");

            //Opretter router. 
            SimpleRouter r = new SimpleRouter(AirportInformation_To_Router, Router_To_SAS, Router_To_KLM, Router_To_SWA);

            //Opretter Flyinformation klasser
            DateTime arrival = new DateTime(1993, 01, 01);
            Flyinformation fSAS = new Flyinformation(arrival, "SAS2233");

            DateTime arrival2 = new DateTime(2022, 09, 22);
            Flyinformation fKLM = new Flyinformation(arrival2, "KLM4455");

            DateTime arrival3 = new DateTime(2023, 04, 23);
            Flyinformation fSWA = new Flyinformation(arrival3, "SWA6677");

            //Opretter besked og sender til router 
            AirportInformation_To_Router.Send(fSAS, fSAS.FlyId);
            AirportInformation_To_Router.Send(fKLM, fKLM.FlyId);
            AirportInformation_To_Router.Send(fSWA, fSWA.FlyId);

            //// SAS modtager, aflæser fra SAS køen. 
            //Message fSasInfo = Router_To_SAS.Receive();
            //fSasInfo.Formatter = new XmlMessageFormatter(new Type[] { typeof(Flyinformation) });
            //Console.WriteLine(fSasInfo.Body.ToString());

            //// KLM modtager, aflæser fra KLM køen. 
            //Message fKlmInfo = Router_To_KLM.Receive();
            //fKlmInfo.Formatter = new XmlMessageFormatter(new Type[] { typeof(Flyinformation) });
            //Console.WriteLine(fKlmInfo.Body.ToString());

            //// SWA modtager, aflæser fra SWA køen. 
            //Message fSwaInfo = Router_To_SWA.Receive();
            //fSwaInfo.Formatter = new XmlMessageFormatter(new Type[] { typeof(Flyinformation) });
            //Console.WriteLine(fSwaInfo.Body.ToString());



            Console.ReadLine();
        }
    }
}
