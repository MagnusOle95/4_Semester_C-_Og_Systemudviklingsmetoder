using Dag9_BusinessLogicCore.BLL;
using Dag9_Dag11_WebApplication.Models;
using Dag9_DTOCore.Model;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dag9_Dag11_WebApplication.Controllers
{
    public class MageController : Controller
    {
        MageBll bll = new MageBll();
        
        private readonly ILogger<MageController> _logger;

        public MageController(ILogger<MageController> logger)
        {
            _logger = logger;
        }

        //Her starter mit. 
        [HttpGet]
        public ActionResult Mageview()
        {
            return View();
        }

        public ActionResult GetMage(IFormCollection formCollection)
        {
            int id = int.Parse(formCollection["ID"]);
            Mage tempMage = bll.GetMage(id);
            ModelMage mm = new ModelMage();
            mm.ID = id;
            mm.Name = tempMage.Name;
            mm.IsDark = tempMage.IsDark;
            return View("MageView",mm);
        }

        public ActionResult GetMageURL(int id)
        {
            Mage tempMage = bll.GetMage(id);
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
            tempMage.IsDark = Boolean.Parse(formCollection["IsDark"]);
            bll.updateMage(tempMage);
            return View("MageView");
        }

        public ActionResult CreateMageView()
        {
            return View();
        }

        public ActionResult CreateMage(IFormCollection formCollection) 
        {
            string Name = formCollection["Name"];
            string NameNoSpace = Name.Replace(" ", "");
            bool IsDark = Boolean.Parse(formCollection["IsDark"]);
            Mage m = new Mage(NameNoSpace, IsDark);
            bll.addMage(m);
            return View("CreateMageView");
        }

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