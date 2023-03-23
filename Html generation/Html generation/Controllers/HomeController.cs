using MyFirstWebApplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyFirstWebApplication.Controllers
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