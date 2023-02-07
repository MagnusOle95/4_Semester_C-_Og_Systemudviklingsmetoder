using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand
{
    public class Synsmand : Mekaniker
    {
        public int AmountOfMOTInaWeek { get; set; }

        public Synsmand(CprNr cprNummer,string name, Adresse adress, int probationaryYear, int amountOfMOTInaWeek) : base(cprNummer,name, adress, probationaryYear, 0)
        {
            AmountOfMOTInaWeek = amountOfMOTInaWeek;
        }

        public override double BeregnUgeLøn()
        {
            return AmountOfMOTInaWeek * 290;
        }

        public override string ToString()
        {
            return base.ToString() + " antal Syn på ugeplan: " + AmountOfMOTInaWeek;
        }


    }
}
