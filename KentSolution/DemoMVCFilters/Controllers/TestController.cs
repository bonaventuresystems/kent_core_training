using DemoMVCFilters.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVCFilters.Controllers
{
    public class TestController : Controller
    {
        // public TestController(ISpellChecker spellChecker)

        public TestController(IEnumerable<ISpellChecker> spellCheckers)
        {
            
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
