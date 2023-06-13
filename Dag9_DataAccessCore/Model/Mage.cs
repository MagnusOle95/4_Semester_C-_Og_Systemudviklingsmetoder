using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DataAccessCore.Model
{
    [Table("Mage")]
    public class Mage
    {
        public int MageId { get; set; }
        public string Name { get; set; }
        public bool IsDark { get; set; }


        public virtual ICollection<Magespell> MageSpells { get; set; }


        //private List<Spell> spells;
        //public virtual List<Spell> Spells { get { return spells; } }

        public Mage()
        {
        }

        public Mage(string name, bool isDark)
        {
            this.Name = name;
            this.IsDark = isDark;
        }

        //public void AddSpell(Spell spell)
        //{
        //    Spells.Add(spell);
        //}

    }



}
