using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RouteTests.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(Nullable<int> id)
        {
            return View();
        }
        public ActionResult Index2(int id)
        {
            return View("Actionlinks");
        }
            
    }
}