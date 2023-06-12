using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedarving_Interfaces_Polymorfi
{
    public class Bil : IBil
    {
        public string Mærke { get; set; }
        public int Årgang { get; set; }

        public Bil(string mærke, int årgang)
        {
            Mærke = mærke;
            Årgang = årgang;
        }

        public virtual void StartMotor()
        {
            Console.WriteLine("Motoren er startet for Bil");
        }

        public override string ToString()
        {
            return Mærke + " " + Årgang;
        }
    }
}

