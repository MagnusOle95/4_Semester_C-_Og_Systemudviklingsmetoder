using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DTOCore.Model
{
    public class Spell
    {

        public Spell(string name, string description)
        {
            Name = name;
            Description = description;
        }
        public int SpellID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return Name + " (" + Description + ")";
        }
    }
}
