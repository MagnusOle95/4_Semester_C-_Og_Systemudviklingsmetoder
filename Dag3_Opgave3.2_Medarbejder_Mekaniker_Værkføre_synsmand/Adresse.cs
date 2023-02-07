using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand
{
    public class Adresse
    {
        public string Vejnavn { get; set; }
        public int Nummer { get; set; }

        public Adresse(string vejnavn, int nummer) 
        {
            Vejnavn= vejnavn;
            Nummer= nummer;
        }

        public override string ToString()
        {
            return Vejnavn + " " + Nummer;
        }



    }
}
