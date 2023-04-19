using Dag9_DataAccessCore.Repositories;
using Dag9_DTOCore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dag9_BusinessLogicCore.BLL
{
    public class MageBll
    {
        public Mage GetMage(int id)
        {
            return MageRepositories.getMage(id);
        }

        public void updateMage(Mage mage)
        {
            MageRepositories.updateMage(mage);
        }

        public void deleteMage(Mage mage) 
        {
            MageRepositories.deleteMage(mage);
        }

        public void addMage(Mage mage)
        {
            MageRepositories.addMage(mage);
        }

        public List<Mage> getMages()
        {
            return MageRepositories.getMages();
        }


        public List<Spell> getMageSpells(int id) 
        {
            return MageRepositories.getMageSpells(id);
        }
    }
}
