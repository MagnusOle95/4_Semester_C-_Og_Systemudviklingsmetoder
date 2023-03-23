using Microsoft.AspNetCore.Mvc;
using Html_generation_CORE.Models;


namespace Html_generation_CORE.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Person p = new Person();
            p.Fornavn = "Ole";
            p.Alder = 3;
            p.Dato = new DateTime(2022, 2, 24);

            return View(p);
        }
        public ActionResult klik(FormCollection formCollection)
        {
            return View();
        }
    }
}