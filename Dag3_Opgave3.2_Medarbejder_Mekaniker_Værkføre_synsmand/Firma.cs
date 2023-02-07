using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Dag3_Opgave3._2_Medarbejder_Mekaniker_Værkføre_synsmand
{
    public class Firma : IharAdresse
    {
        public Adresse Adress { get; set; }
        public Firma(Adresse adresse)
        {
            Adress = adresse;
        }

        public override string ToString()
        {
            return "Adresse: " + Adress;
        }
    }
}
