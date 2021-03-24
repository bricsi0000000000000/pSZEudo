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
            var incomingValidityBegin = new DateTime(int.Parse(collection["ValidityBegin.Year"]),
                                                 int.Parse(collection["ValidityBegin.Month"]),
                                                 int.Parse(collection["ValidityBegin.Day"]));
            vehicle.ValidityBegin = incomingValidityBegin;

            var incomingTechnicalValidity = new DateTime(int.Parse(collection["TechnicalValidity.Year"]),
                                                 int.Parse(collection["TechnicalValidity.Month"]),
                                                 int.Parse(collection["TechnicalValidity.Day"]));
            vehicle.TechnicalValidity = incomingTechnicalValidity;

            var incomingRegisterDate = new DateTime(int.Parse(collection["RegisterDate.Year"]),
                                                 int.Parse(collection["RegisterDate.Month"]),
                                                 int.Parse(collection["RegisterDate.Day"]));
            vehicle.RegisterDate = incomingRegisterDate;

            var incomingPlacedInTrafficDate = new DateTime(int.Parse(collection["PlacedInTrafficDate.Year"]),
                                                 int.Parse(collection["PlacedInTrafficDate.Month"]),
                                                 int.Parse(collection["PlacedInTrafficDate.Day"]));
            vehicle.PlacedInTrafficDate = incomingPlacedInTrafficDate;

            VehicleManager.addToList(vehicle);

            return View("Index", VehicleManager.VehicleList);
        }
    }
}
