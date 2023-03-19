using Microsoft.AspNetCore.Mvc;

namespace Dag11_Opgave1_ASP_Start.Controllers
{
    public class CalculatorController : Controller
    {
    
        [HttpGet]
        public ActionResult TimeCalculator()
        { 
            return View();   
        }

        [HttpPost]
        public ActionResult TimeCalculator(IFormCollection formCollection)
        {
            int hours = int.Parse(formCollection["Hours"]);
            int minutes = int.Parse(formCollection["Minutes"]);
            int seconds = int.Parse(formCollection["Seconds"]);
            TimeSpan ts = new TimeSpan(0, hours, minutes, seconds);
            double total = ts.TotalSeconds;
            ViewBag.Hours = hours;
            ViewBag.Minutes = minutes;
            ViewBag.Seconds = seconds;
            ViewBag.Total = total;
            return View("TimeCalculator2");
        }

    }
}
