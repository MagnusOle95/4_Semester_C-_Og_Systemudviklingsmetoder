using Dag14_Opgave1_Countrys.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System.Text.Json;

namespace Dag14_Opgave1_Countrys.Controllers
{
    public class HomeController : Controller
    {
        List<SelectListItem> countries = new List<SelectListItem>();

        public IActionResult Index(string Countries)
        {
            if (HttpContext.Session.GetString("countries") == null)
            {
                countries.Add(new SelectListItem { Text = "China", Value = "CN" });
                countries.Add(new SelectListItem { Text = "Danmark", Value = "DK" });
                countries.Add(new SelectListItem { Text = "United states", Value = "US" });

                string jsonStr = JsonSerializer.Serialize(countries);
                HttpContext.Session.SetString("countries", jsonStr);
            }
            else
            {
                String Json = HttpContext.Session.GetString("countries");
                countries = JsonSerializer.Deserialize<List<SelectListItem>>(Json);
            }
            ViewBag.Countries = countries;
            ViewBag.CountryCode = Countries;
            return View();
        }

        [HttpPost]
        public IActionResult Index(IFormCollection formData) 
        {
      
            String Json = HttpContext.Session.GetString("countries");
            countries = JsonSerializer.Deserialize<List<SelectListItem>>(Json);

            countries.Add(new SelectListItem { Text = formData["tbCountry"], Value = formData["tbCode"] });

            string jsonStr = JsonSerializer.Serialize(countries);
            HttpContext.Session.SetString("countries", jsonStr);

            ViewBag.Countries = countries;

            return View();

        }




    }
}