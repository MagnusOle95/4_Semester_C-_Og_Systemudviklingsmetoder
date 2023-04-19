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
            Dag9_DTOCore.Model.Mage tempMage = new Dag9_DTOCore.Model.Mage(mage.Name, mage.IsDark);
            tempMage.MageId = mage.MageId;
            return tempMage;
        }

        public static Mage MapMage(Dag9_DTOCore.Model.Mage mage)
        {
            Mage tempMage = new Mage(mage.Name, mage.IsDark);
            tempMage.MageId = mage.MageId;
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
            return tempSpell;
        }

    }
}
