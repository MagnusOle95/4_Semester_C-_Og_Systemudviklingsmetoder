using Dag15_Opgave1_Person.Models;
using Microsoft.AspNetCore.Mvc;

namespace Dag15_Opgave1_Person.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult VisPersonView(int id)
        {
            return View("PersonView",id);
        }

        public IActionResult FindPerson(string fornavn, string efternavn)
        {
            Person p = new Person();
            p.ForNavn = fornavn;
            p.EfterNavn = efternavn;
            return View("FindPersonView",p);

        }








    }
}
