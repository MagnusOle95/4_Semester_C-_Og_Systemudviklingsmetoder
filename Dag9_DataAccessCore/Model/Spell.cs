using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DataAccessCore.Model
{
    [Table("Spell")]
    public class Spell
    {
        public int SpellID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<Magespell> MageSpells { get; set; }

        public Spell()
        {
        }

        public Spell(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

    }
}
