using JWT.Algorithms;
using JWT.Builder;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SafeAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
      public class LoginController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] LoginModel value)
        {
            if (value.UserName == "abc" && value.Password == "123")
            {
                var token = JwtBuilder.Create()
                      .WithAlgorithm(new HMACSHA256Algorithm())
                      .WithSecret("8383838383838383838383838383838383")
                      .Encode(value);


                return Ok(token);
            }
            else
            {
                return BadRequest("Invalid username or password");
            }
        }

    }

    public class LoginModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
