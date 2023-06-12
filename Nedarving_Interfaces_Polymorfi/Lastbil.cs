using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nedarving_Interfaces_Polymorfi
{
    internal class Lastbil : Bil
    {
        public int Lastkapacitet { get; set; }

        public Lastbil(string mærke, int årgang, int lastkapacitet) : base(mærke, årgang)
        {
            Lastkapacitet = lastkapacitet;
        }

        public override void StartMotor()
        {
            Console.WriteLine("Motoren er startet for Lastbil");
        }

        public void LøftLast()
        {
            Console.WriteLine("Lasten løftes af en lastbil.");
        }

        public override string ToString()
        {
            return base.ToString() + " " + Lastkapacitet;
        }
    }
}
