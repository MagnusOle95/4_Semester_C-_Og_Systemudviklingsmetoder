using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Person
    {
        private string navn;

        public Person(string navn)
        {
            this.navn = navn;
        }

        public string Name
        {
            get { return navn; }
            set { navn = value; }
        }

        public override string ToString()
        {
            return this.navn;

        }

    }


}
