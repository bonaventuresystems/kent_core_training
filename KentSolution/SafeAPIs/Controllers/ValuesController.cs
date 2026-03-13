using Microsoft.AspNetCore.Mvc;
using SafeAPIs.Filter;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SafeAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AuthFilter]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

    }
}
