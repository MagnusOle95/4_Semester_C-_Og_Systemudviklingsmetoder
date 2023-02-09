using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dag4_Opgave1_Point_To_Point_Channel
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opretter Kør
            //MessageQueue.Create(@".\Private$\ATC_To_AIC");

            //Opretter Forbindelse til kør.
            MessageQueue ATC_To_AIC = new MessageQueue(@".\Private$\ATC_To_AIC");

            //Opretter Flyinformation klasse
            DateTime arrival = new DateTime(1993, 01, 01);
            Flyinformation f1 = new Flyinformation(arrival, "Sas2233");

            //Opretter besked og sender til kø fra Airport trafik controle.
            ATC_To_AIC.Send(f1, f1.FlyId);

            // Airport information center modtager fly information 
            Message finfo = ATC_To_AIC.Receive();
            finfo.Formatter = new XmlMessageFormatter(new Type[] { typeof(Flyinformation) });

            Console.WriteLine(finfo.Body.ToString());

            Console.ReadLine();



        }
    }
}
