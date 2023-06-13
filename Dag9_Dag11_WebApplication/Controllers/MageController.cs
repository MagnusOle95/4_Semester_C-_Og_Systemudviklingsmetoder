using Dag9_BusinessLogicCore.BLL;
using Dag9_Dag11_WebApplication.Models;
using Dag9_DTOCore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dag9_Dag11_WebApplication.Controllers
{
    //[Route("Mage")]
    public class MageController : Controller
    {
        MageBll bll = new MageBll();
        
        private readonly ILogger<MageController> _logger;

        public MageController(ILogger<MageController> logger)
        {
            _logger = logger;
        }

        //Her starter mit.
        [Route("GetMage")]
        public ActionResult Mageview()
        {
            return View();
        }

        
        public ActionResult GetMage(IFormCollection formCollection)
        {
            int id = int.Parse(formCollection["ID"]);

            Mage tempMage;

            try
            {
                tempMage = bll.GetMage(id);
            }
            catch
            {
                tempMage = null;
            }

            if (tempMage != null)
            {
                ModelMage mm = new ModelMage();
                mm.ID = id;
                mm.Name = tempMage.Name;
                mm.IsDark = tempMage.IsDark;
                return View("MageView",mm);
            }
            ViewBag.fejl = "Fejl";
            return View("MageView");
        }

        [Route("GetMage/{id}")]
        public ActionResult GetMageURL(int id)
        {
            Mage tempMage;

            try
            {
                tempMage = bll.GetMage(id);
            }
            catch
            {
                tempMage = null;
            }

            ModelMage mm = new ModelMage();
            mm.ID = id;
            mm.Name = tempMage.Name;
            mm.IsDark = tempMage.IsDark;
            return View("MageView",mm);
        }

        public ActionResult updateMage(IFormCollection formCollection)
        {
            int id = int.Parse(formCollection["ID"]);
            Mage tempMage = bll.GetMage(id);
            tempMage.Name = formCollection["Name"];

            bool IsDark;
            try
            {
                IsDark = Boolean.Parse(formCollection["IsDark"]);
            }
            catch
            {
                IsDark = false;
            }

            tempMage.IsDark = IsDark;
            bll.updateMage(tempMage);
            return View("MageView");
        }

        [Route("CreateMage")]
        public ActionResult CreateMageView()
        {
            return View();
        }

        public ActionResult CreateMage(IFormCollection formCollection) 
        {
            string Name = formCollection["Name"];
            string NameNoSpace = Name.Replace(" ", "");
            bool IsDark;
            try
            {
                IsDark = Boolean.Parse(formCollection["IsDark"]);
            }
            catch 
            {
                IsDark = false;
            }

            Mage m = new Mage(NameNoSpace, IsDark);
            bll.addMage(m);
            return View("CreateMageView");
        }

        [Route("DeleteMage")]
        public ActionResult DeleteMageView()
        {
            ViewBag.Magelist = bll.getMages();
            return View();
        }

        public ActionResult ShwoMageInDeleteMage(string selectedItem)
        {
            string s = selectedItem;
            string[] sArray = s.Split(' ');
            int mageID = Int32.Parse(sArray[2]);
            Mage tempMage = bll.GetMage(mageID);
            return Json(new { success = true, name = tempMage.Name, isDark = tempMage.IsDark, mageId = tempMage.MageId });
        }

        public ActionResult DeleteMage(IFormCollection formCollection)
        {
            int id = int.Parse(formCollection["ID"]);
            Mage tempMage = bll.GetMage(id);
            bll.deleteMage(tempMage);
            ViewBag.Magelist = bll.getMages();
            return View("DeleteMageView");
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}