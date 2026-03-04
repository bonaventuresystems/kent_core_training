using DemoMVCFilters.Filters;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DemoMVCFilters.Controllers
{
   
    public class HomeController : BaseController
    {

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Dashboard()
        {
            return View();
        }

        public IActionResult About(int? id)
        {
            var result = 10 / id;
            return View();
        }


        //public IActionResult About(int? id)
        //{
        //    if (id.HasValue)
        //    {
        //        return View();
        //    }
        //    else
        //    {
        //        throw new Exception("My ERR");
        //    }
        //}

        //public IActionResult About(int? id)
        //{
        //    try
        //    {
        //        if (id.HasValue)
        //        {
        //            return View();
        //        }
        //        else
        //        {
        //            throw new Exception("My ERR");
        //        }
        //    }
        //    catch (Exception ex)
        //    {

        //        return View("Error", ex);
        //    }

        //}

    }
}
