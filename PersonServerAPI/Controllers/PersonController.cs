using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PersonServerAPI.Model;

namespace PersonServerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        [Route("alle")]
        [HttpGet]
        public List<Person> GetAllePersoner()
        {
            //try catch
            return Personer.GetAllePersons();
        }

        [Route("PersonById/{Id}")]
        [HttpGet]
        public Person PersonById(int Id)
        {
            //try catch
            return Personer.GetPersonById(Id);
        }

        [Route("CreatePerson/{Name}/{Age}")]
        [HttpPost]
        public void CreatePerson(string Name, int Age)
        {
            Personer.createPerson(Name, Age);
        }
    }
}
