using Dag16_Opgave2_Partial_view_og_View_component.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Dag16_Opgave2_Partial_view_og_View_component.Controllers
{
    public class HomeController : Controller
    {
        public List<Person> getList()
        {
            List<Person> personListe = new List<Person>();
            Person Morden = new Person("Morden", 23);
            Person magnus = new Person("Magnus", 27);
            personListe.Add(Morden);
            personListe.Add(magnus);
            return personListe;
        }
        
        public IActionResult VisAlle()
        {
            ViewBag.liste = getList();
            return View();
        }

        public IActionResult VisEn()
        {
            Person p = getList().ElementAt(0);
            return View(p);
        }


    }
}