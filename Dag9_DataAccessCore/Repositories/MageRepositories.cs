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
            List<Spell> outList = new List<Spell>();

            using (MageContex context = new MageContex())
            {
                var mageSpells = context.Magespells
                    .Where(ms => ms.MageId == Id)
                    .Include(ms => ms.Spell)  // This can help improve performance by reducing the number of database queries needed to retrieve the required data.
                    .Select(ms => ms.Spell)
                    .ToList();

                foreach(var spell in mageSpells) 
                {
                    outList.Add(MageMapper.spellMapper(spell));
                }
            }
            return outList;
        }

      




    }
}
