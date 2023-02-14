using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag5_Opgave1_Tilføj_MapListe_Til_AIC_Og_Flyinformation_Klasse
{
    public class Flyinformation
    {
        public DateTime Arrivaltime { get; set; }
        public String FlyId { get; set; }

        public Flyinformation(DateTime arrivalTime, string flyId) 
        {
            
            Arrivaltime = arrivalTime;
            FlyId= flyId;
        }

        public Flyinformation() { }

        public override string ToString()
        {
            return "Ankomst: " + Arrivaltime + " FlyId: " + FlyId;
        }
    }

}
