using DemoMVCFilters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVCFilters.Controllers
{

    [KentAuth]
    public class SampleController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.UserName =  HttpContext.Session.GetString("UserName");
            return View();
        }
    }
}
