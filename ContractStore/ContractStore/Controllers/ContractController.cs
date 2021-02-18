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
    }
}
