using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Clients.Models;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly ClientContext _context;

        public ClientsController(ClientContext context)
        {
            _context = context;
        }

        // GET: api/Clients1
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetTodoItems()
        {
          if (_context.ClientsItem == null)
          {
              return NotFound();
          }
            return await _context.ClientsItem.ToListAsync();
        }

        // GET: api/Clients1/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(long id)
        {
          if (_context.ClientsItem == null)
          {
              return NotFound();
          }
            var client = await _context.ClientsItem.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients1/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(long id, Client client)
        {
            if (id != client.ID)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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
        
        // POST: api/Clients1
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client clientItem)
        {
            _context.ClientsItem.Add(clientItem);
            await _context.SaveChangesAsync();

            //    return CreatedAtAction("GetTodoItem", new { id = todoItem.Id }, todoItem);
            return CreatedAtAction(nameof(GetClient), new { id = clientItem.ID}, clientItem);
        }

        // DELETE: api/Clients1/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(long id)
        {
            if (_context.ClientsItem == null)
            {
                return NotFound();
            }
            var client = await _context.ClientsItem.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.ClientsItem.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(long id)
        {
            return (_context.ClientsItem?.Any(e => e.ID == id)).GetValueOrDefault();
        }
        private readonly ILogger<ClientsController> _logger;
        public ClientsController(ILogger<ClientsController> logger) =>
        _logger = logger;

        protected  async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("SomeCommands", DateTimeOffset.UtcNow);
                await Task.Delay(1_000, stoppingToken);
            }
        }
    }
}
