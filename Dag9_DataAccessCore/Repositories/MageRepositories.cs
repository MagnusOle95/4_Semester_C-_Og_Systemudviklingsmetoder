using Dag9_DataAccessCore.Context;
using Dag9_DataAccessCore.Mappers;
using Dag9_DTOCore.Model;
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

        public static List<Spell> getMageSpells(int id)
        {
            List<int> tempMageSpellIDlist = new List<int>();
            List<Spell> spells = new List<Spell>();

            using (MageContex context = new MageContex())
            {
                foreach (var item in context.Magespells)
                {
                    if(item.MageId == id)
                    {
                        tempMageSpellIDlist.Add(item.SpellId);
                    }
                }

                foreach (int t in tempMageSpellIDlist)
                {
                    spells.Add(MageMapper.spellMapper(context.Spells.Find(t)));
                }
            }
            return spells;
        }




    }
}
