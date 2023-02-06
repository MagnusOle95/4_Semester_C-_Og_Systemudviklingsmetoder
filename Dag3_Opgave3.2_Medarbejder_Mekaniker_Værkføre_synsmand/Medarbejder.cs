using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand
{
    public abstract class Medarbejder
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public int WorkingHours { get;}


        public Medarbejder(string name, string adress) 
        {
            Name= name;    
            Adress= adress;
            WorkingHours = 37;
        }

        public abstract double BeregnUgeLøn();

        public override string ToString()
        {
            return "Navn: " + Name + " Adresse: " + Adress;
        }

    }
}
