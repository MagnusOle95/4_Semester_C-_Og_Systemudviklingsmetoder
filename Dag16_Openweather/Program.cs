using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using Dag16_PatternLibary;
namespace Dag16_Openweather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ////Opretter transaktionskør kør. 
            //MessageQueue.Create(@".\Private$\FromWeatherAPI_TO_Filter");
            //MessageQueue.Create(@".\Private$\TO_publicSUB1");
            //MessageQueue.Create(@".\Private$\ToATCFilter");
            //MessageQueue.Create(@".\Private$\ATCQueue");
            //MessageQueue.Create(@".\Private$\FailQueue");
            //MessageQueue.Create(@".\Private$\ToAICFilter");
            //MessageQueue.Create(@".\Private$\ToAirLineCompFilter");
            //MessageQueue.Create(@".\Private$\AICQueue");
            //MessageQueue.Create(@".\Private$\ToPublicSub2");
            //MessageQueue.Create(@".\Private$\ToAirCompStringFormat");
            //MessageQueue.Create(@".\Private$\ToAirCompClassFormat");
            //MessageQueue.Create(@".\Private$\ToAirCompXMLFormat");

            //Forbinder til køerne. 
            MessageQueue FromWeatherAPI_TO_Filter = new MessageQueue(@".\Private$\FromWeatherAPI_TO_Filter");
            MessageQueue TO_publicSUB1 = new MessageQueue(@".\Private$\TO_publicSUB1");
            MessageQueue ToATCFilter = new MessageQueue(@".\Private$\ToATCFilter");
            MessageQueue ATCQueue = new MessageQueue(@".\Private$\ATCQueue");
            MessageQueue FailQueue = new MessageQueue(@".\FailQueue");
            MessageQueue ToAICFilter = new MessageQueue(@".\Private$\ToAICFilter");
            MessageQueue ToAirLineCompFilter = new MessageQueue(@".\Private$\ToAirLineCompFilter");
            MessageQueue AICQueue = new MessageQueue(@".\Private$\AICQueue");
            MessageQueue ToPublicSub2 = new MessageQueue(@".\Private$\ToPublicSub2");
            MessageQueue ToAirCompStringFormat = new MessageQueue(@".\Private$\ToAirCompStringFormat");
            MessageQueue ToAirCompClassFormat = new MessageQueue(@".\Private$\ToAirCompClassFormat");
            MessageQueue ToAirCompXMLFormat = new MessageQueue(@".\Private$\ToAirCompXMLFormat");


            //Opretter api weather.
            Api_weather aw = new Api_weather(FromWeatherAPI_TO_Filter);

            //Opretter filterWeatherFormat 
            FilterWeatherFormat FWea = new FilterWeatherFormat(FromWeatherAPI_TO_Filter, TO_publicSUB1);

            //Opretter Public sub1 pattern og liste af outQueues.
            List<MessageQueue> QueueList1 = new List<MessageQueue>();
            QueueList1.Add(ToATCFilter);
            QueueList1.Add(ToAICFilter);
            QueueList1.Add(ToAirLineCompFilter);
            PublicSub1 ps1 = new PublicSub1(TO_publicSUB1, QueueList1);

            //Opretter filterATCFormat 
            FilterATCFormat FATC = new FilterATCFormat(ToATCFilter, ATCQueue);

            //Opretter filterAICPattern
            FilterAICFormat FAIC = new FilterAICFormat(ToAICFilter, AICQueue);

            //Opretter filterAlirlineCompFormat
            FilterAirlineCompFormat FACF = new FilterAirlineCompFormat(ToAirLineCompFilter, ToPublicSub2);

            //Opretter public sub. 
            List<MessageQueue> AirlineFormat = new List<MessageQueue>();
            AirlineFormat.Add(ToAirCompStringFormat);
            AirlineFormat.Add(ToAirCompClassFormat);
            AirlineFormat.Add(ToAirCompXMLFormat);
            PublicSub1 ps2_ToAirLineComp = new PublicSub1(ToPublicSub2, AirlineFormat);










            //Henter weather forecast ned. 
            aw.getWeather();


            Console.ReadLine();


        }
    }
}
