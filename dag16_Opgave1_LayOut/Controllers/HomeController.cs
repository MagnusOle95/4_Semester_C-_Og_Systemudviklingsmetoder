using dag16_Opgave1_LayOut.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace dag16_Opgave1_LayOut.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Sale()
        {
            return View();
        }

        public IActionResult MoreSales()
        {
            return View();
        }

        public IActionResult Buy()
        {
            return View();
        }

        public IActionResult BuyAndSell()
        {
            return View();
        }



    }
}