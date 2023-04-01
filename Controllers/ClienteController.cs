using FacturacionHogar.Context;
using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models;
using FacturacionHogar.models.DTO_s;
using FacturacionHogar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

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
        /// <summary>
        /// Este metodo crea los usuarios que se utilizaran para los recibos y facturas.
        /// </summary>
        /// <param name="cliente">Los detalles del nuevo usuario que se deben proporcionar en el cuerpo de la petición los encuentras en el ejemplo:</param>
        /// <returns>dentro del objeto que se retorna en la variable result, devuelve el estado de la creacion y en la variable error, si hubieron errores</returns>
        [HttpPost("CrearCliente")]
        public Response<bool> CrearCliente([FromBody] ClienteCreateDto cliente)
        {
            var servicio = crearServicio();
            return servicio.CrearCliente(cliente).Result;
        }
        [HttpPost("ActualizarCliente")]
        public Response<bool> ActualizarCliente([FromBody] ClienteUpdateDto cliente)
        {
            var servicio = crearServicio();
            return servicio.ActualizarCliente(cliente).Result;
        }
    }
}
