using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Firma
    {
        private List<Bil> biler = new List<Bil>();
        private String navn;
        private String adresse;
        public virtual List<Bil> Biler
        {
            get
            {
                return biler;
            }
        }
        public virtual List<Ejer> Ejere { get; } = new List<Ejer>();

        public int FirmaId { get; set; }
        public string Navn { get => navn; set => navn = value; }
        public string Adresse { get => adresse; set => adresse = value; }

        public override String ToString()
        {
            return Navn + " " + Adresse;
        }
    }
}
