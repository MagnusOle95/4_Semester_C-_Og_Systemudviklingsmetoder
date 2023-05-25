using Dag9_DataAccessCore.Repositories;
using Dag9_DTOCore.Model;
using External_API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;

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

        //Its update a MagesLeanedSpells
        public void updateMageLeanedSPells(Mage mage, List<Spell> spells ) 
        {
            MageRepositories.updateMageLeanedSPells(mage, spells);
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


        public List<Spell> getMageSpells(Mage mage) 
        {
            return MageRepositories.getMageSpells(mage);
        }

        public List<Spell> getSpells()
        {
            return MageRepositories.getSpells();
        }

        public XElement getQuitichWeatherForSchooles(string city, string countrycode)
        {
            return WeatherAPI.GetQuidditchWeatherForSchooles(city, countrycode);
        }

        public List<School> getSchools() 
        {
            return MageRepositories.getSchools();
        }

    }
}
