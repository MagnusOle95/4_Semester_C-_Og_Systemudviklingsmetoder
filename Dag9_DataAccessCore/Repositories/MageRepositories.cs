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


        public static List<Spell> getMageSpells(int Id)
        {
            List<Spell> list = new List<Spell>();
            using (MageContex context = new MageContex())
            {
                var mage = context.Mages.Include(m => m.MageSpells).ThenInclude(ms => ms.Spell).FirstOrDefault(m => m.MageId == Id);

                if (mage != null)
                {
                    foreach (var mageSpell in mage.MageSpells)
                    {
                        list.Add(MageMapper.spellMapper(mageSpell.Spell));
                    }
                }

            }
            return list;
        }

        //public static List<Spell> getMageSpells(int id)
        //{
        //    List<Spell> spells = new List<Spell>();

        //    using (MageContex context = new MageContex())
        //    {
        //        using (MageContex context2 = new MageContex())
        //        {
        //            foreach (var item in context.Magespells)
        //            {
        //                if (item.MageId == id)
        //                {
        //                    spells.Add(MageMapper.spellMapper(context2.Spells.Find(item.SpellId)));

        //                }
        //            }

        //        }
        //    }
        //    return spells;
        //}




    }
}
