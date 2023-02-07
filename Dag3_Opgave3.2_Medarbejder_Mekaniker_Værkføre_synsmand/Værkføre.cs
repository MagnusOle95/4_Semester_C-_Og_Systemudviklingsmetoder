using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand
{
    internal class Værkføre : Mekaniker
    {
        public int ChosentoJob { get; set; }
        public double SalarySupplement { get; set; }

        public Værkføre(CprNr cprNummer,string name, string adress, int probationaryYear, double salary, int chosenJob, double salarySupplement) :base(cprNummer,name,adress,probationaryYear,salary)
        {
            ChosentoJob = chosenJob;
;           SalarySupplement = salarySupplement;
        }

        public override double BeregnUgeLøn()
        {
            return (base.Salary * base.WorkingHours) + SalarySupplement;
        }

        public override string ToString()
        {
            return base.ToString() + " Valgt til jobbet: " + ChosentoJob + " Tilæg til løn: " + SalarySupplement;
        }
    }
}
