using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag13_Opgave1_Recipient_Router
{
    internal class RecipientRouter
    {
        public IDictionary<string, MessageQueue> CountryQueue { get; set; }
        
        public RecipientRouter(IDictionary<string, MessageQueue> countryQueues)
        {
            this.CountryQueue = countryQueues;
        }


        public void CheckPassengerPassPort(XElement p)
        {

            ////Parse stringen fra køen til en xml fil igen. 
            //StreamReader reader = new StreamReader(message.BodyStream);
            //XElement body = XElement.Parse(reader.ReadToEnd());

            var passenger = p.Element("Passenger");
            Console.WriteLine(passenger);

            //Finder alle pasportne frem og ligger dem i et array.  
            var passports = p.Elements("Passport");
            Console.WriteLine(passports);

            foreach (var l in passports)
            {
                //Finder køen frem det akutelle pas passer på. 
                MessageQueue CQ = CountryQueue[l.Element("Nationality").Value];
                //Laver Parent xmlElement og putter alt relavant information ind i denne.
                XElement parentElement = new XElement("PassengerInformation");
                parentElement.Add(passenger);
                parentElement.Add(l);
                //Sender til køen. 
                CQ.Send(parentElement);

            }
        }

    }
}
