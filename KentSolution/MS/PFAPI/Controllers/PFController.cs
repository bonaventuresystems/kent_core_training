using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Messaging.ServiceBus;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PFAPI.Models;

namespace PFAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class PFController : ControllerBase
    {
        private readonly Jddb2Context _context;

        public PFController(Jddb2Context context)
        {
            _context = context;
        }

        // GET: api/PF
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Pf>>> GetPfs()
        {
            string connectionString = "Endpoint=sb://kenttech.servicebus.windows.net/;SharedAccessKeyName=RootManageSharedAccessKey;SharedAccessKey=Zjy9B/Ffi5CgYRK1Zp98RWKexVDgVk5pF+ASbNDJ27U=";
            string queueName = "azureorderqueue";

            await using var client = new ServiceBusClient(connectionString);
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);

            IReadOnlyList<ServiceBusReceivedMessage> receivedMessages = await receiver.ReceiveMessagesAsync(10);
            if (receivedMessages == null)
            {
                return null;
            }

            foreach (ServiceBusReceivedMessage receivedMessage in receivedMessages)
            {
                string body = receivedMessage.Body.ToString();
                var messageCreated = JsonConvert.DeserializeObject<Emp>(body);

                var pfObj = new Pf
                {
                    Cno = messageCreated.No
                };

                await _context.Pfs.AddAsync(pfObj);
                await _context.SaveChangesAsync();
                await receiver.CompleteMessageAsync(receivedMessage);
            }
            return await _context.Pfs.ToListAsync();
        }

        // GET: api/PF/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Pf>> GetPf(int id)
        {
            var pf = await _context.Pfs.FindAsync(id);

            if (pf == null)
            {
                return NotFound();
            }

            return pf;
        }

        // PUT: api/PF/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPf(int id, Pf pf)
        {
            if (id != pf.Pfacno)
            {
                return BadRequest();
            }

            _context.Entry(pf).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PfExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/PF
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Pf>> PostPf(Pf pf)
        {
            _context.Pfs.Add(pf);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPf", new { id = pf.Pfacno }, pf);
        }

        // DELETE: api/PF/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePf(int id)
        {
            var pf = await _context.Pfs.FindAsync(id);
            if (pf == null)
            {
                return NotFound();
            }

            _context.Pfs.Remove(pf);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PfExists(int id)
        {
            return _context.Pfs.Any(e => e.Pfacno == id);
        }
    }
}
