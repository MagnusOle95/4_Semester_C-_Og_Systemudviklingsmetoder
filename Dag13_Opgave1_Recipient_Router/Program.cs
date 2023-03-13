using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag13_Opgave1_Recipient_Router
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opretter kører. 
            //MessageQueue.Create(@".\Private$\PersonRegisterUs");
            //MessageQueue.Create(@".\Private$\PersonRegisterUk");
            //MessageQueue.Create(@".\Private$\PersonRegisterDk");
            //MessageQueue.Create(@".\Private$\PersonRegisterSwe");
            //MessageQueue.Create(@".\Private$\PersonRegisterGer");

            //Forbinder til køen. 
            MessageQueue PrUs = new MessageQueue(@".\Private$\PersonRegisterUs");
            MessageQueue PrUk = new MessageQueue(@".\Private$\PersonRegisterUk");
            MessageQueue PrDk = new MessageQueue(@".\Private$\PersonRegisterDk");
            MessageQueue PrSwe = new MessageQueue(@".\Private$\PersonRegisterSwe");
            MessageQueue PrGer = new MessageQueue(@".\Private$\PersonRegisterGer");

            //Henter XMP Fil fra drev 
            XElement PassengerInformation = XElement.Load(@"Passenger_Nationalitet_Information.xml");
            Console.WriteLine(PassengerInformation);

            //Opretter Dictionary af køer så det er nemmere at holde styr på. 
            IDictionary<string, MessageQueue> countryQueues = new Dictionary<string, MessageQueue>();
            countryQueues.Add("US",PrUs);
            countryQueues.Add("UK", PrUk);
            countryQueues.Add("DK", PrDk);
            countryQueues.Add("S", PrSwe);
            countryQueues.Add("D", PrGer);

            //Opretter  RecipientRouter 
            RecipientRouter rR1 = new RecipientRouter(countryQueues);

            //Køre routeren. 
            rR1.CheckPassengerPassPort(PassengerInformation);


            Console.ReadLine();
        }
    }
}
