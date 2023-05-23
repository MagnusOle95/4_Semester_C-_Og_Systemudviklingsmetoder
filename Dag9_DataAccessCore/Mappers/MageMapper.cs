using Dag9_DataAccessCore.Context;
using Dag9_DataAccessCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DataAccessCore.Mappers
{
    internal class MageMapper
    {
        public static Dag9_DTOCore.Model.Mage MapMage(Mage mage)
        {
            if (mage != null)
            {
                Dag9_DTOCore.Model.Mage tempMage = new Dag9_DTOCore.Model.Mage(mage.Name, mage.IsDark);
                tempMage.MageId = mage.MageId;
                tempMage.MageSpells = (ICollection<Dag9_DTOCore.Model.MageSpell>)mage.MageSpells;
                return tempMage;
            }
            else
            {
                return null;
            }
        }

        public static Mage MapMage(Dag9_DTOCore.Model.Mage mage)
        {
            Mage tempMage = new Mage(mage.Name, mage.IsDark);
            tempMage.MageId = mage.MageId;
            tempMage.MageSpells = (ICollection<Magespell>)mage.MageSpells;
            return tempMage;
        }

        internal static void Update(Dag9_DTOCore.Model.Mage mage, Mage dataMage)
        {
            dataMage.Name= mage.Name;
            dataMage.IsDark = mage.IsDark;
        }

        public static Dag9_DTOCore.Model.Spell spellMapper(Spell spell)
        {
            Dag9_DTOCore.Model.Spell tempSpell = new Dag9_DTOCore.Model.Spell(spell.Name, spell.Description);
            tempSpell.SpellID = spell.SpellID;
            tempSpell.MageSpells = (ICollection<Dag9_DTOCore.Model.MageSpell>)spell.MageSpells;
            return tempSpell;
        }

        public static Spell spellmapper(Dag9_DTOCore.Model.Spell spell)
        {
            Spell TempSpell = new Spell(spell.Name, spell.Description);
            TempSpell.SpellID = spell.SpellID;
            TempSpell.Description = spell.Description;
            TempSpell.Name = spell.Name;
            return TempSpell;
        }

    }
}
