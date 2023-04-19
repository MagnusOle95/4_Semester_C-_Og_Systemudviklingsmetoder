using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using validationexamples.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace validationexamples.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View(new Person());
        }
    
        [HttpPost]
        public ActionResult Completed(Person person)
        {
            if (!ModelState.IsValid)
            {
                Debug.Write("Model state is NOT valid");
               // ModelState.AddModelError("modelerror", "use of fake name");
                //The input was not legal, so we just show an empty person
                return View(new Person());
            }
            //We create the view with the person.
            return View(person);
        }
    }
}