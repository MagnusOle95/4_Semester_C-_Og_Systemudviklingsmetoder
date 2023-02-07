using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand
{
    public class Mekaniker : Medarbejder
    {
        public int ProbationaryYear { get; set; }
        public virtual double Salary { get; set; }

        public Mekaniker(CprNr cprNummer,string name, string adress,int probationaryYear, double salary): base(cprNummer,name,adress) 
        {
            ProbationaryYear= probationaryYear;
            Salary= salary;
        }

        public override double BeregnUgeLøn()
        {
            return Salary * base.WorkingHours;
        }

        public override string ToString()
        {
            return base.ToString() + " Svendeprøve år: " + ProbationaryYear + " Løn: " + Salary;
        }
    }

}