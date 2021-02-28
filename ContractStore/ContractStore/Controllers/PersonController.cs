using ContractStore.Models.People;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContractStore.Controllers
{
    public class PersonController : Controller
    {
        public IActionResult Index()
        {
            return View(PersonManager.People);
        }

        public ActionResult AddPerson()
        {
            return View("AddPerson");
        }

        [HttpPost]
        public IActionResult AddPerson(Person person, IFormCollection collection)
        {
            var incomingBirthDate = new DateTime(int.Parse(collection["BirthDate.Year"]),
                                                 int.Parse(collection["BirthDate.Month"]),
                                                 int.Parse(collection["BirthDate.Day"]));
            person.BirthDate = incomingBirthDate;
            PersonManager.People.Add(person);

            return View("Index", PersonManager.People);
        }
    }
}
