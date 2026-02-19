using DemoMVC.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVC.Controllers
{
    [MyActionLogCode]
    public abstract class BaseController : Controller
    {
    }
}
