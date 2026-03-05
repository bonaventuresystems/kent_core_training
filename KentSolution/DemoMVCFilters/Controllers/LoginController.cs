using DemoMVCFilters.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVCFilters.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(KentUser user)
        {
            if (user.UserName == "admin" && user.Password == "123")
            {
                HttpContext.Session.SetString("UserName", user.UserName);
                return RedirectToAction("Index", "Sample");
            }
            else
            {
                ViewBag.ErrorMessage = "Invalid username or password.";
                return View();
            }
        }

        public IActionResult Signout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("SignIn");
        }
    }
}
