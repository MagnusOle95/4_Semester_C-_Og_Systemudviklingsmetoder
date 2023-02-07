using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand
{
    public class CprNr
    {
        public String BirthDate { get; set; }
        public String SequenceNumber { get; set; }

        public CprNr(String bDate, String sNumber)
        {
            BirthDate = bDate;
            SequenceNumber = sNumber;
        }

        public string ToString()
        {
            return "Fødselsdato: " + BirthDate + " CprNummer: " + SequenceNumber;
        }


    }
}
