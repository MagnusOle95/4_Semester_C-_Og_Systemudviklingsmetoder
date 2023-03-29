using Microsoft.AspNetCore.Mvc;
using RouteTests.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace RouteTests.Controllers
{
    public class ShopController : Controller
    {
      
       /* The Books Action method   */
        public ActionResult Book(string id, string kategori)
        {
            //first check if the id parameter is empty
            if (!String.IsNullOrEmpty(id))
                ViewBag.id = id;
            else
                ViewBag.id = "no id";
            //then check if the category parameter is empty
            if (!String.IsNullOrEmpty(kategori))
                ViewBag.category = kategori;
            else
                ViewBag.category = "no category";
            //go to the view
            return View("Books");
        }

        public ActionResult FullBook(Book book)
        {
            return View("FullBook", book);
        }



        // GET: Test
        public ActionResult Index()
        {
            return View("View");
        }
    }
}