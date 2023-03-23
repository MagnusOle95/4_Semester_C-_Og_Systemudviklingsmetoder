using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Text;
using System.Threading.Tasks;
using Dag16_Patterns_Net_framework;


namespace Dag16_Openweather
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Opretter transaktionskør kør. 
            //MessageQueue.Create(@".\Private$\FromWeatherAPI_TO_Filter");
            //MessageQueue.Create(@".\Private$\FromFilterATC_TO_publicSUB1");
            

            //Forbinder til køerne. 
            MessageQueue FromWeatherAPI_TO_Filter = new MessageQueue(@".\Private$\FromWeatherAPI_TO_Filter");
            MessageQueue FromFilterATC_TO_publicSUB1 = new MessageQueue(@".\Private$\FromFilterATC_TO_publicSUB1");
            

            //Opretter api weather.
            Api_weather aw = new Api_weather(FromWeatherAPI_TO_Filter);

            //Opretter filterATCFormat 
            FilterATCFormat FATC = new FilterATCFormat(FromWeatherAPI_TO_Filter,FromFilterATC_TO_publicSUB1);

            //Henter weather forecast ned. 
            aw.getWeather();


            Console.ReadLine();


        }
    }
}
