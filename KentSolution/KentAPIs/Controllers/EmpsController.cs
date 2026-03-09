using Microsoft.AspNetCore.Mvc;
using KentAPIs.Models;
using Microsoft.AspNetCore.Cors;

namespace KentAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class EmpsController : ControllerBase
    {
        KentDbContext db = new KentDbContext();
        // GET: api/<EmpsController>
        [HttpGet]
        public IEnumerable<Emp> Get()
        {
            return db.Emps.ToList();
        }

        // GET api/<EmpsController>/5
        [HttpGet("{id}")]
        public Emp Get(int id)
        {
            return db.Emps.Find(id);
        }

        // POST api/<EmpsController>
        [HttpPost]
        public void Post([FromBody] Emp value)
        {
            db.Emps.Add (value);
            db.SaveChanges();
        }

        // PUT api/<EmpsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Emp value)
        {
           Emp old = db.Emps.Find(id);
           old.Name = value.Name;
           old.Address = value.Address;
           db.SaveChanges();
        }

        // DELETE api/<EmpsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Emp tobeDeleted = db.Emps.Find(id);
            db.Emps.Remove(tobeDeleted);
            db.SaveChanges();
        }

        public int Add(int v1, int v2)
        {
            //Actual Logic
            return v1 + v2;
        }
    }
}
