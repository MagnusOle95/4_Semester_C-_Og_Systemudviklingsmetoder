using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    [Table("Bil")]
    public class Bil
    {
        public int BilID { get; set; }
        public string Name { get; set; }
        public int Weight { get; set; }
        public bool Diesel { get; set; }
        public int Age { get; set; }
        
        //public virtual Firma? Firma { get; set; }

        internal Bil(int BilID, string name, int weight)
        {
            this.BilID = BilID;
            Name = name;
            Weight = weight;
            Age = 10;
        }

        public Bil()
        {
        }
        public Bil(string name, int weight)
        {
            Name = name;
            Weight = weight;
            Age = 10;
        }

        public override string ToString()
        {
            return Name + " " + Weight;
        }
    }

}
