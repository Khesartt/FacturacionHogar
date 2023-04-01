using FacturacionHogar.Context;
using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models;
using FacturacionHogar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        ClienteService crearServicio()
        {
            ApiContext db = new();
            ClienteService clienteService = new(db);
            return clienteService;
        }

        [HttpPost("CrearCliente")]
        public Response<bool> CrearCliente([FromBody] Cliente cliente)
        {
            var servicio = crearServicio();
            return servicio.CrearCliente(cliente).Result;
        }
        [HttpPost("ActualizarCliente")]
        public Response<bool> ActualizarCliente([FromBody] Cliente cliente)
        {
            var servicio = crearServicio();
            return servicio.ActualizarCliente(cliente).Result;
        }
    }
}
