using DemoEFMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoEFMVC.Controllers
{
    public class DemoController : Controller
    {
        KentContext db = new KentContext(); 


        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Create(Customer cust)
        {
            if(ModelState.IsValid)
            {
                db.Customers.Add(cust);
                db.SaveChanges();
                return new ContentResult() { Content = "Done!" };
            }
            else
            {
                return View(cust);
            }
        
        }

    }
}
