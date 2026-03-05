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
            //ViewData["Master"] = "~/Views/Shared/WeekDayMaster.cshtml";
            ViewBag.Master = "~/Views/Shared/WeekDayMaster.cshtml";
            return View();
        }

        public IActionResult About()
        {
            ViewBag.Title = "About Us!";
            ViewBag.Master = "~/Views/Shared/WeekDayMaster.cshtml";
            return View();
        }
    }
}
