using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Messaging;

namespace Dag11_Opgave2_3_Transforming
{
    public class SasFlyinformation
    {
        public string Airline { get; set; }
        public string FlightNo { get; set; }
        public string Destination { get; set; }
        public string Origin { get; set; }
        public string ArrivalDeparture { get; set; }
        public string Dato { get; set; }//6. marts 2017
        public string Tidspunkt { get; set; }//16:45

        public SasFlyinformation(string airline, string flightnr, string destination, string origin, string arrivaldepature, string dato, string tidspunkt)
        {
            Airline = airline;
            FlightNo = flightnr;
            Destination = destination;
            Origin= origin;
            ArrivalDeparture= arrivaldepature;
            Dato = dato;
            Tidspunkt = tidspunkt;
        }

        public SasFlyinformation() { }

        public string ToString()
        {
            return Airline + " " + FlightNo + " " + Destination + " " + Origin + " " + ArrivalDeparture + " " + Dato + " " + Tidspunkt;
        }

    }
}
