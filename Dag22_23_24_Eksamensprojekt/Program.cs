using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dag22_23_24_Eksamensprojekt
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //////Opretter kør.
            //MessageQueue.Create(@".\Private$\From_CRead_IDM_To_Router");
            //MessageQueue.Create(@".\Private$\From_Router_To_LMS");
            //MessageQueue.Create(@".\Private$\From_Router_To_PAYS");

            //Forbinder til køerne. 
            MessageQueue From_CRead_IDM_To_Router = new MessageQueue(@".\Private$\From_CRead_IDM_To_Router");
            MessageQueue From_Router_To_LMS = new MessageQueue(@".\Private$\From_Router_To_LMS");
            MessageQueue From_Router_To_PAYS = new MessageQueue(@".\Private$\From_Router_To_PAYS");

            //Opretter router. 
            ContentbasedRouter router = new ContentbasedRouter(From_CRead_IDM_To_Router, From_Router_To_LMS, From_Router_To_PAYS);

            //Henter XML fil ind i systemet. 
            XmlDocument IDMCheckIn = new XmlDocument();
            IDMCheckIn.Load("C:\\C#\\4_Semester_C++++_Og_Systemudviklingsmetoder\\Dag22_23_24_Eksamensprojekt\\IDMChechin.xml");

            XmlDocument IDMPayInfo = new XmlDocument();
            IDMPayInfo.Load("C:\\C#\\4_Semester_C++++_Og_Systemudviklingsmetoder\\Dag22_23_24_Eksamensprojekt\\IDMPayinfo.xml");

            //Nu sender jeg dem til routern. 
            From_CRead_IDM_To_Router.Send(IDMCheckIn);
            //From_CRead_IDM_To_Router.Send(IDMPayInfo);


            Console.ReadLine();

        }
    }
}
