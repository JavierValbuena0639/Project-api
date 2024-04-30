using Microsoft.AspNetCore.Mvc;
using Project_api.Model;
using Project_api.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private readonly IClientsService _clientService;

        public ClientController(IClientsService clientService)
        {
            _clientService = clientService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Clients>>> GetAllClients()
        {
            var clients = await _clientService.GetAllClients();
            return Ok(clients);
        }

        [HttpGet("{clientId}")]
        public async Task<ActionResult<Clients>> GetClientById(int clientId)
        {
            var client = await _clientService.GetClientById(clientId);
            if (client == null)
            {
                return NotFound();
            }
            return Ok(client);
        }

        [HttpPost]
        public async Task<ActionResult<Clients>> CreateClient(Clients client)
        {
            var createdClient = await _clientService.CreateClient(client);
            return CreatedAtAction(nameof(GetClientById), new { clientId = createdClient.IdClient }, createdClient);
        }

        [HttpPut("{clientId}")]
        public async Task<IActionResult> UpdateClient(int clientId, Clients client)
        {
            if (clientId != client.IdClient)
            {
                return BadRequest();
            }

            var updatedClient = await _clientService.UpdateClient(client);
            if (updatedClient == null)
            {
                return NotFound();
            }

            return NoContent();
        }

        [HttpDelete("{clientId}")]
        public async Task<IActionResult> DeleteClient(int clientId)
        {
            var result = await _clientService.DeleteClient(clientId);
            if (!result)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
