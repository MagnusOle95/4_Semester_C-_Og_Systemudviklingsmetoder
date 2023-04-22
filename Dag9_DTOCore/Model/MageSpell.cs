using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DTOCore.Model
{
    public class MageSpell
    {

        public MageSpell(int mageid, int spellid)
        {
            MageId =mageid;
            SpellId = spellid;
        }

        public int MagespellId { get; set; }
        public int MageId { get; set; }
        public int SpellId { get; set; }
        public Mage Mage { get; set; }
        public Spell Spell { get; set; }
    }
}
