using ContractStore.Models.People;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics.Contracts;

namespace ContractStore.Controllers
{
    public class ContractController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult People()
        {
            ViewBag.People = PersonManager.People;
            return View("People");
        }

        public IActionResult Vehicles()
        {
            return View("Vehicles");
        }
    }
}
