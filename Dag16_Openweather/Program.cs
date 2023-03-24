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
            //Opretter transaktionskør kør.
            MessageQueue.Create(@".\Private$\FromWeatherAPI_TO_Filter");
            MessageQueue.Create(@".\Private$\FromFilterATC_TO_publicSUB1");
            MessageQueue.Create(@".\Private$\ATCQueue");
            MessageQueue.Create(@".\Private$\ToAICFilter");
            MessageQueue.Create(@".\Private$\ToAirLineCompFilter");


            //Forbinder til køerne. 
            MessageQueue FromWeatherAPI_TO_Filter = new MessageQueue(@".\Private$\FromWeatherAPI_TO_Filter");
            MessageQueue FromFilterATC_TO_publicSUB1 = new MessageQueue(@".\Private$\FromFilterATC_TO_publicSUB1");
            MessageQueue ATCQueue = new MessageQueue(@".\Private$\ATCQueue");
            MessageQueue ToAICFilter = new MessageQueue(@".\ToAICFilter");
            MessageQueue ToAirLineCompFilter = new MessageQueue(@".\Private$\ToAirLineCompFilter");

            //Opretter api weather.
            Api_weather aw = new Api_weather(FromWeatherAPI_TO_Filter);

            //Opretter filterATCFormat 
            FilterATCFormat FATC = new FilterATCFormat(FromWeatherAPI_TO_Filter,FromFilterATC_TO_publicSUB1);

            //Opretter Public sub1 pattern og liste af outQueues.
            List<MessageQueue> QueueList1 = new List<MessageQueue>();
            QueueList1.Add(ATCQueue);
            QueueList1.Add(ToAICFilter);
            QueueList1.Add(ToAirLineCompFilter);
            PublicSub1 dd = new PublicSub1(FromFilterATC_TO_publicSUB1, QueueList1);
            






            //Henter weather forecast ned. 
            aw.getWeather();


            Console.ReadLine();


        }
    }
}
