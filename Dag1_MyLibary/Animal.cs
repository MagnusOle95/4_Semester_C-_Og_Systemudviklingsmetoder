using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyLibrary
{
    public class Animal : Ianimal
    {
        string species;
        public Animal(string species)
        {
            this.species = species;
        }

        public bool isDog()
        {
            if(species == "hund")
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        public override string ToString()
        {
            return "Race på dyr: " + this.species;

        }
    }
}
