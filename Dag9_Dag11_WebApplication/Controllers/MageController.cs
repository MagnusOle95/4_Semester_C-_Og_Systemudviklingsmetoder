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
            ViewBag.Name = tempMage.Name;
            ViewBag.IsDark = tempMage.IsDark;
            return View("MageView");
        }

        public ActionResult GetMageURL(int id)
        {
            Mage tempMage = bll.GetMage(id);
            ViewBag.Name = tempMage.Name;
            ViewBag.IsDark = tempMage.IsDark;
            return View("MageView");
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

        [HttpGet]
        public ActionResult CreateMageView()
        {
            return View();
        }






        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}