using FacturacionHogar.Application.DataTransferObjects;
using FacturacionHogar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionHogar.Controllers
{
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly IClientService clientService;

        public ClientController(IClientService clientService)
        {

            this.clientService = clientService;
        }


        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var clients = await this.clientService.GetClientsAsync();

            return this.Ok(clients);
        }

        [HttpPut("Add")]
        public async Task<IActionResult> AddClient([FromBody] InfoClient infoClient)
        {
            Client client = await this.clientService.AddClientAsync(infoClient);

            return this.Ok(client);
        }
    }
}
