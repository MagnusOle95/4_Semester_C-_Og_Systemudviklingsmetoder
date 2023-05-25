using Dag9_DataAccessCore.Context;
using Dag9_DataAccessCore.Mappers;

using Dag9_DTOCore.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_DataAccessCore.Repositories
{
    public class MageRepositories
    {
        public static Mage getMage(int id)
        {
            using (MageContex context = new MageContex())
            {
                return MageMapper.MapMage(context.Mages.Find(id));
            }
        }

        public static void updateMage(Mage mage)
        {
            using (MageContex context = new MageContex())
            {
                Model.Mage dataMage = context.Mages.Find(mage.MageId);
                MageMapper.Update(mage, dataMage);
                context.SaveChanges();

            }
        }

        public static void updateMageLeanedSPells(Mage mage, List<Spell> spells)
        {
            List<Spell> Spells = new List<Spell>();
            using (MageContex context = new MageContex())
            {
                foreach(Spell s in spells)
                {
                    // Check if the Magespell already exists
                    bool magespellExists = context.Magespells.Any(ms => ms.MageId == mage.MageId && ms.SpellId == s.SpellID);

                    if (!magespellExists)
                    {
                        context.Magespells.Add(new Model.Magespell { MageId = mage.MageId, SpellId = s.SpellID });
                    }
                }

                
                List<int> LeanedSpellsID = new List<int>();
                foreach(Spell s in spells)
                {
                    LeanedSpellsID.Add(s.SpellID);
                }

                List<int> intDBLeanedSpells = new List<int>();
                foreach (var ms in context.Magespells)
                {
                    intDBLeanedSpells.Add(ms.SpellId);
                }

                var magespellsNotInList = intDBLeanedSpells.Except(LeanedSpellsID);

                foreach(var sID in magespellsNotInList)
                {
                    var MagespellFromID = context.Magespells
                       .FirstOrDefault(e => e.MageId == mage.MageId && e.SpellId == sID);

                    if (MagespellFromID != null)
                    {
                        context.Magespells.Remove(MagespellFromID);
                        context.SaveChanges();
                    }
                }
                context.SaveChanges();

            }
         
        }


        public static void deleteMage(Mage mage) 
        {
            using (MageContex context = new MageContex())
            {
                Model.Mage dataMage = context.Mages.Find(mage.MageId);
                context.Mages.Remove(dataMage);
                context.SaveChanges();
            }
        }

        public static void addMage(Mage mage)
        {
            using (MageContex context = new MageContex())
            {
                context.Mages.Add(MageMapper.MapMage(mage));
                context.SaveChanges();
            }
        }

        public static List<Mage> getMages()
        {
            List<Mage> outList = new List<Mage>();

            using (MageContex context = new MageContex())
            {
                foreach(var item in context.Mages)
                {
                    outList.Add(MageMapper.MapMage(item));
                }
            }
            return outList;
        }


        public static List<Spell> getMageSpells(Mage mage)
        {
            List<Spell> outList = new List<Spell>();

            
            using (MageContex context = new MageContex())
            {
                var Spells = context.Mages
                    .Where(m => m.Equals(MageMapper.MapMage(mage)))
                    .SelectMany(m => m.MageSpells)
                    .Select(ms => ms.Spell)
                    .ToList();

                foreach(var spell in Spells) 
                {
                    outList.Add(MageMapper.spellMapper(spell));
                }
            }
            return outList;
        }

        public static List<Spell> getSpells()
        {
            List<Spell> outList = new List<Spell>();

            using (MageContex context = new MageContex())
            {
                foreach (var item in context.Spells)
                {
                    outList.Add(MageMapper.spellMapper(item));
                }
            }
            return outList;
        }

        public static List<School> getSchools()
        {
            List<School> outList = new List<School>();

            using (MageContex context = new MageContex())
            {
                foreach (var item in context.Schools)
                {
                    outList.Add(MageMapper.schoolMapper(item));
                }
            }
            return outList;
        }





    }
}
