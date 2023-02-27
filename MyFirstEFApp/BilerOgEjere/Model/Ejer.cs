using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Ejer
    {
        public int EjerId { get; set; }
        public String EjerNavn { get; set; }
        public virtual List<Firma> Firmaer { get; } = new List<Firma>();

        public Ejer(string ejerNavn) : this()
        {
            EjerNavn = ejerNavn;
        }

        public Ejer()
        {
            Firmaer = new List<Firma>();
        }

        public override string ToString()
        {
            return EjerNavn;
        }
    }
}
