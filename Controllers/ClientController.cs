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


        [HttpGet("GetClients")]
        public async Task<IActionResult> GetAllUsers()
        {
            var clients = await this.clientService.GetClientsAsync();

            return this.Ok(clients);
        }
    }
}
