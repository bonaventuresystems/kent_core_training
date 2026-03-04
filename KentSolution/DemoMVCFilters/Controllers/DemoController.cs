using DemoMVCFilters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVCFilters.Controllers
{
    [KentResultFilter]
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home!";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us!";
            return View();
        }
    }
}
