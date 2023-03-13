using Microsoft.AspNetCore.Mvc;

namespace Dag11_Opgave1_ASP_Start.Controllers
{
    public class FruitController : Controller
    {
        public IActionResult fruits()
        {
            string[] fruits = new string[] { "Bananer", "Appelsiner", "Jønkers", "Æbler", "Rosiner", "Ostehapse" };
            ViewBag.fruits = fruits;
            return View();
        }

    }
}
