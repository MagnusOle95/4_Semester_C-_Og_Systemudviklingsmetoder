using System;
using System.Collections.Generic;
using System.Linq;
using System.Messaging;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Dag16_PatternLibary
{
    public class Api_weather
    {
        protected MessageQueue OutQueue;
        public Api_weather(MessageQueue outQueue)
        {
            this.OutQueue = outQueue;
        }

        public void getWeather()
        {
            // Replace {YOUR_API_KEY} with your OpenWeatherMap API key
            //string apiKey = "{YOUR_API_KEY}";
            string apiKey = "9aba5e6816c13be0e3162ef5280821a8";

            // Replace {CITY_NAME} with the name of the city you want to get the forecast for
            //string city = "{CITY_NAME}";
            string city = "Paris";

            // Replace {COUNTRY_CODE} with the ISO 3166 country code of the city
            //string countryCode = "{COUNTRY_CODE}";
            string countryCode = "FR";

            // Build the API URL
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&mode=xml&units = imperial,{countryCode}&appid={apiKey}";

            // Make a request to the API and get the response as XML
            WebClient client = new WebClient();
            string response = client.DownloadString(apiUrl);

            Console.WriteLine(response);

            // Parse the XML response into an XmlDocument
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(response);

            // Save the XML document to a file
            xmlDoc.Save("forecast.xml");

            Console.WriteLine("Forecast saved to forecast.xml.");

            //sender XML til kø
            OutQueue.Send(xmlDoc);
        }
    }
}
