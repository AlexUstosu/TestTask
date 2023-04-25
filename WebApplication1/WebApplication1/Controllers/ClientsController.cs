using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using System.Collections.Generic;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClientsController : ControllerBase
    {
        public IClientsRepository ClientsItems { get; set; }
        public ClientsController(IClientsRepository clientItems)
        {
            ClientsItems = clientItems;
        }
        private readonly ILogger<ClientsController> _logger;

        //public IEnumerable<Client> GetAll()
        //{
        //    return ClientsItems.GetAll();
        //}

        [HttpGet(Name = "GetById{id: long}")]
        public IActionResult GetById(long id)
        {
            var item = ClientsItems.Get(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }

    }
}
