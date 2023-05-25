using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

namespace External_API
{
    public class WeatherAPI
    {
        private static XmlDocument getWeather(string city, string countryCode)
        {
            // Replace {YOUR_API_KEY} with your OpenWeatherMap API key
            //string apiKey = "{YOUR_API_KEY}";
            string apiKey = "9aba5e6816c13be0e3162ef5280821a8";

            // Build the API URL
            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?q={city}&mode=xml&units = imperial,{countryCode}&appid={apiKey}";

            // Make a request to the API and get the response as XML
            WebClient client = new WebClient();
            string response = client.DownloadString(apiUrl);

            // Parse the XML response into an XmlDocument
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(response);

            //Returning the XML File. 
            return xmlDoc;
        }

        public static XElement GetQuidditchWeatherForSchooles(string city, string countryCode) 
        {
            List<XElement> QuidditchWeatherForSchooles = new List<XElement>();

            XmlDocument Pari = getWeather(city,countryCode);

            //Parse stringen fra køen til en xml fil igen. 
            XElement WeatherAPI_XMLDOC = XElement.Parse(Pari.OuterXml);

            //Finder de informationer jeg skal bruge. 
            string nameOfCityString = WeatherAPI_XMLDOC.Element("city").Attribute("name").Value;
            var nameOfCityXElement = XElement.Parse("<nameOfCity>" + nameOfCityString + "</nameOfCity>");


            var country = WeatherAPI_XMLDOC.Element("city").Element("country");


            var stringTemperature = WeatherAPI_XMLDOC.Element("temperature").Attribute("value").Value;
            //Laver det fra kelvin til grader C
            double doubleTemperature = double.Parse(stringTemperature, CultureInfo.InvariantCulture);
            doubleTemperature = Math.Round(doubleTemperature - 273.15, 2);
            var temperature = XElement.Parse("<temperatureC>" + doubleTemperature + "</temperatureC>");


            string windString = WeatherAPI_XMLDOC.Element("wind").Element("speed").Attribute("name").Value;
            var wind = XElement.Parse("<windspeed>" + windString + "</windspeed>");


            string cloudsString = WeatherAPI_XMLDOC.Element("clouds").Attribute("name").Value;
            var clouds = XElement.Parse("<clouds>" + cloudsString + "</clouds>");


            int timezoneOffset = Int32.Parse(WeatherAPI_XMLDOC.Element("city").Element("timezone").Value);
            //DateTimeOffset currentTimeOffset = DateTimeOffset.UtcNow.AddSeconds(timezoneOffset);
            DateTime currentTimeOffset = DateTime.UtcNow.AddSeconds(timezoneOffset);
            string currettimeS = currentTimeOffset + "";
            var time = XElement.Parse("<time>" + currettimeS.Substring(11) + "</time>");



            //Tilføjer alle de informationer til xElement.
            XElement WeatherXElement = new XElement("Wheather_for_Schoole");
            WeatherXElement.Add(nameOfCityXElement);
            WeatherXElement.Add(country);
            WeatherXElement.Add(temperature);
            WeatherXElement.Add(wind);
            WeatherXElement.Add(clouds);
            WeatherXElement.Add(time);


            return WeatherXElement;
            //return WeatherAPI_XMLDOC;
        }



    }
}
