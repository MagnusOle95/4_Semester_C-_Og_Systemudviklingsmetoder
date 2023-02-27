using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag8_Opgave1_MinFørste_EF_App.Model
{
    [Table("Bil")]
    public class Bil
    {
        public int BILID { get; set; }
        public string Name { get; set; }
        public int Weigth { get; set; }
        public bool Diesel { get; set; }
        public int Age { get; set; }
        //public Person Ejer { get; set; }
        internal Bil(string name, int weigth, bool diesel)
        {
            Name = name;
            Weigth = weigth;
            Diesel = diesel;
            Age= 10;
            //Ejer = ejer;
            //ejer.Biler.Add(this);
        }

        public Bil()
        {
        }

        public override string ToString()
        {
            return "Bil id:" + BILID + " Navn:" + Name + " Vægt:" + Weigth + " Dielsel:" + Diesel + " Alder:" + Age;
        }

      


    }
}
