using ContractStore.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContractStore.Controllers
{
    public class PersonController : Controller
    {
        public List<Person> People = new List<Person>();

        public IActionResult Index()
        {
            ViewBag.People = new List<Person>()
            {
                new Person(){
                    ID = 1,
                    FirstName = "Béla",
                    LastName = "Last name"
                },
                new Person(){
                    ID = 2,
                    FirstName = "Béla1",
                    LastName = "Last name1"
                }
            };

            return View();
        }
    }
}
