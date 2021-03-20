using ContractStore.Models.Vehicle;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ContractStore.Controllers
{
    public class VehicleController : Controller
    {
        public IActionResult Index()
        {
            return View(VehicleManager.VehicleList);
        }

        public ActionResult AddVehicle()
        {
            return View("AddVehicle");
        }

        [HttpPost]
        public IActionResult AddVehicle(Vehicle vehicle, IFormCollection collection)
        {
            VehicleManager.VehicleList.Add(vehicle);

            return View("Index", VehicleManager.VehicleList);
        }
    }
}
