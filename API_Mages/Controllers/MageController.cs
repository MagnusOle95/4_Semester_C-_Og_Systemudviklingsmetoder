using Dag9_BusinessLogicCore.BLL;
using Dag9_DTOCore.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;

namespace API_Mages.Controllers
{
    [Route("")]
    [ApiController]
    public class MageController : ControllerBase
    {
        MageBll bll = new MageBll();

        [HttpGet]
        public ActionResult<string> Get()
        {
            return "Hello, Mages!";
        }

        [HttpGet("getMage/{id}")]
        public ActionResult<Mage> GetById(int id)
        {
            Mage mage = bll.GetMage(id);

            if (mage == null)
            {
                return NotFound();
            }

            return mage;
        }

        [HttpGet("getMages")]
        public ActionResult<List<Mage>> GetMages()
        {
            List<Mage> mages = bll.getMages();

            if (mages == null || mages.Count() == 0)
            {
                return NotFound();
            }

            return mages;
        }

        [HttpGet("getMageSpells/{id}")]
        public ActionResult<List<Spell>> getmageSpell(int id)
        {
            Mage mage = bll.GetMage(id);
            List<Spell> spells = bll.getMageSpells(mage);

            if (spells == null)
            {
                return NotFound();
            }

            return spells;
        }

        [HttpGet("getSpells")]
        public ActionResult<List<Spell>> GetSpells()
        {
            List<Spell> spells = bll.getSpells();

            if (spells == null || spells.Count() == 0)
            {
                return NotFound();
            }

            return spells;
        }

        [HttpGet("getQuitichWeather/{city}/{countrycode}")]
        public ActionResult<string> getQuitichWeatherForSchooles(string city, string countrycode)
        {
            
            XElement qWeather = bll.getQuitichWeatherForSchooles(city, countrycode);

            if (qWeather == null)
            {
                return NotFound();
            }

            return qWeather.ToString();
        }

        [HttpGet("getSchools")]
        public ActionResult<List<School>> GetSchools()
        {
            List<School> schools = bll.getSchools();

            if (schools == null ||schools.Count() == 0)
            {
                return NotFound();
            }

            return schools;
        }

        //Virker fra swagger men ikke URL, da den manger en request body. 
        [HttpPost("createMage/{name}/{isdark}")]
        public ActionResult<Mage> createMage(string name, string isdark)
        {
            bool isdarkbool = Boolean.Parse(isdark); 
            Mage m = new Mage(name, isdarkbool);
            bll.addMage(m);
            return m;
        }

        [HttpPut("updateMage/{id}/{name}/{isdark}")]
        public ActionResult<Mage> updateMage(int id, string name, string isdark)
        {
            bool isdarkbool = Boolean.Parse(isdark);

            Mage m = bll.GetMage(id);

            if(m == null)
            {
                return NotFound();
            }

            m.Name = name;
            m.IsDark = isdarkbool;

            bll.updateMage(m);

            return m;
        }

        [HttpDelete("deleteMage/{id}")]
        public ActionResult<string> deleteMage(int id)
        {
            Mage m = bll.GetMage(id);
            
            if(m == null)
            {
                return NotFound();
            }

            bll.deleteMage(m);

            return m.Name + " ID:" + m.MageId + " deleted from the database";
        }











    }
}
