using Microsoft.AspNetCore.Mvc;
using Shoes.Models;
using System.Diagnostics;

namespace Shoes.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Completed(Shoe shoe)
        {
            if (!ModelState.IsValid)
            {
                Debug.Write("Model state is NOT valid");
                // ModelState.AddModelError("modelerror", "use of fake name");
                //The input was not legal, so we just show an empty person
                return View(new Shoe());
            }
            //We create the view with the person.
            return View(shoe);
        }

    }
}