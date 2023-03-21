using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;
using System.Xml.Linq;

namespace Dag15_EventDrivenConsumer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opretter kør. 
            //MessageQueue.Create(@".\Private$\CheckInEmployee");

            //Forbinder til køerne. 
            MessageQueue messageQueue = new MessageQueue(@".\Private$\CheckInEmployee");


            //Viser boks og skriv data ind. 
            while (true)
            {
                //Bruger indtaster reservationsnummer 
                Console.WriteLine("Indtast reservationsnummer:");  // Prompt the user to enter a string
                string resNr = Console.ReadLine();  // Read the input string from the console
                XElement ReservationsNummer = new XElement("Reservationsnummer");
                ReservationsNummer.Add(resNr);

                //Bruger indtaster navn. 
                Console.WriteLine("Indtast kundes navn:");  // Prompt the user to enter a string
                string cosName = Console.ReadLine();  // Read the input string from the console
                XElement CostumerName = new XElement("Costumername");
                CostumerName.Add(cosName);

                //Bruger indtaster alder.  
                Console.WriteLine("Indtast Kundes alder:");  // Prompt the user to enter a string
                string cosAge = Console.ReadLine();  // Read the input string from the console
                XElement CostumerAge = new XElement("Costumerage");
                CostumerAge.Add(cosAge);

                //afventer emplyee bekæfter og sender informationen. 
                Console.WriteLine("Tryk vilkårlig knap for at sende information:");
                Console.ReadKey();  // Wait for the user to press a key before closing the console window

                //Opretter beskeden
                XElement xe = new XElement("Message");
                xe.Add(ReservationsNummer);
                xe.Add(CostumerName);
                xe.Add(CostumerAge);
                Console.WriteLine(xe);

                //Sender besked til køen. 
                messageQueue.Send(xe,cosName);

            }

        }
    }
}
