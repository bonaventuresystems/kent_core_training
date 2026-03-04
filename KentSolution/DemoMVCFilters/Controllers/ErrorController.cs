using Microsoft.AspNetCore.Mvc;

namespace DemoMVCFilters.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Handle(string message)
        {
            ViewBag.message = message;
            return View();
        }
    }
}
