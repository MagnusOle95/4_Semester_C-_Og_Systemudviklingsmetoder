using Dag11_Opgave1_ASP_Start.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dag11_Opgave1_ASP_Start.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public string Index()
        {
            return "hej :D";
        }

        public IActionResult index2()
        {
            string navn = "Magnus Smukke Larsen";
            int alder = 27;

            ViewData["navn"] = navn;
            ViewBag.alder = alder;

            return View();
        }



        public IActionResult Privacy()
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