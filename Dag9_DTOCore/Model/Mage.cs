using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DTOCore.Model
{
    public class Mage
    {
        public Mage(string name, bool isdark)
        {
            Name = name;
            IsDark = isdark;
        }

        public int MageId { get; set; }
        public string Name { get; set; }
        public bool IsDark { get; set; }
        public virtual ICollection<MageSpell> MageSpells { get; set; }
        public override string ToString()
        {
            return "ID: " + MageId + " Navn: " + Name;
        }

    }
}
