using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DTOCore.Model
{
    public class Mage
    {
        public Mage(int mageId,string name, bool isdark) 
        {
            MageId = mageId;
            Name = name;
            IsDark = isdark;

        }

        public int MageId { get; set; }
        public string Name { get; set; }
        public bool IsDark { get; set; }
        //public List<Spell> spells { get; set; }
    }
}
