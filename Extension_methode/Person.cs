using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Extension_methode
{
    public class Person
    {
        public Person(string navn, int alder, string køn) 
        {
            Navn = navn;
            Alder = alder;
            Køn = køn;
        }

        public string Navn { get; set; }
        public int Alder { get; set; }
        public string Køn { get; set; }
    }
}
