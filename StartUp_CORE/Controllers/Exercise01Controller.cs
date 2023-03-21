using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNetCore.Mvc;

namespace Lesson02_Startup.Controllers
{
    public class Exercise01Controller : Controller
    {
        

        public ActionResult Index()
        {
            // create a new product object with instance name glass
            Product glass = new Product("Wine glass", 160.50);
            glass.ImageUrl = "grandcru.jpg";
            ViewBag.Glass = glass;

            //Creating a bin 
            Product bin = new Product("Bin", 199.95);
            bin.ImageUrl = "bin_35l.jpg";
            ViewBag.Bin = bin;

            //Creating a knife. 
            Product knife = new Product("Knife", 19.99, "st_knife.jpg","Mordens Knive");
            ViewBag.Knife = knife;

            return View();
        }

    }
}
