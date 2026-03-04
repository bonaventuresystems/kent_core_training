using DemoMVCFilters.Filters;
using Microsoft.AspNetCore.Mvc;

namespace DemoMVCFilters.Controllers
{
    [LogActionResultFilter]
    public abstract class BaseController : Controller
    {
    }
}
