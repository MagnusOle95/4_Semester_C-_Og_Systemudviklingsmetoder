using Microsoft.AspNetCore.Mvc;
using ModelBinding.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ModelBinding.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(int id)
        {
            //Find person med id = id
            Person p = new Person();
            p.Fornavn = "Ole";
            p.Efternavn = "hansen";
            p.Alder = 35;
            return View("opret",p);
        }

        //[HttpPost]
        //public ActionResult Index(FormCollection formCollection)
        //{
        //    String fornavn = formCollection["Fornavn"];
        //    string efternavn = formCollection["Efternavn"];
        //    int alder = int.Parse(formCollection["Alder"]);
        //    return View();
        //}
        [HttpPost]
        //public ActionResult Index(Person person)
        //{
        //    return View();
        //}
        public ActionResult Index(String Fornavn, String efternavn, int alder)
        {
            return View();
        }

    }
}