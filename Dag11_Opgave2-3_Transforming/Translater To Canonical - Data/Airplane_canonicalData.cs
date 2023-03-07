using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dag11_Opgave2_3_Transforming.Translater_To_Canonical___Data
{
    public class Airplane_canonicalData
    {
        public string AirlineName { get; set; }
        public string FlightNo { get; set; }
        public string DepartureAirport { get; set; }
        public string DestinationAirport { get; set; }
        public string Status { get; set; }
        public DateTime Tidspunkt { get; set; }

        public Airplane_canonicalData(string airlineName, string flightNo, string departureAirport, string destinationAirport, string status, DateTime tidspunkt)
        {
            AirlineName = airlineName;
            FlightNo = flightNo;
            DepartureAirport = departureAirport;
            DestinationAirport = destinationAirport;
            Status = status;
            Tidspunkt = tidspunkt;
        }

        public Airplane_canonicalData() 
        {
        }

        public string ToString()
        {
            return AirlineName + " " + FlightNo + " " + DepartureAirport + " " + DestinationAirport + " " + Status + " " + Tidspunkt;
        }
    }
}
