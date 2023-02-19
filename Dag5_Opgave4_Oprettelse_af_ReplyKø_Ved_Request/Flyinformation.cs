using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag5_Opgave4_Oprettelse_af_ReplyKø_Ved_Request
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
