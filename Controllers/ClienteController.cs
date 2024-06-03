using FacturacionHogar.Context;
using FacturacionHogar.models;
using FacturacionHogar.models.domain;
using FacturacionHogar.models.DTO_s;
using FacturacionHogar.Services;
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

        /// <summary>
        /// Crear Usuario.
        /// </summary>
        /// <param name="cliente">Los detalles del nuevo usuario que se deben proporcionar en el cuerpo de la petición los encuentras en el ejemplo:</param>
        /// <returns>dentro del objeto que se retorna en la variable Result, devuelve el estado de la creacion y en la variable error, si hubieron errores</returns>
        [HttpPost("CrearCliente")]
        public Response<bool> CrearCliente([FromBody] ClienteCreateDto cliente)
        {
            var servicio = crearServicio();
            return servicio.CrearCliente(cliente).Result;
        }

        /// <summary>
        /// actualizar Usuario.
        /// </summary>
        /// <param name="cliente">Los detalles de los campos para actualizar el usuario que se deben proporcionar en el cuerpo de la petición los encuentras en el ejemplo:</param>
        /// <returns>dentro del objeto que se retorna en la variable Result, devuelve el estado de la actualizacion y en la variable error, si hubieron errores</returns>
        [HttpPost("ActualizarCliente")]
        public Response<bool> ActualizarCliente([FromBody] ClienteUpdateDto cliente)
        {
            var servicio = crearServicio();
            return servicio.ActualizarCliente(cliente).Result;
        }

        /// <summary>
        /// Eliminar Usuario.
        /// </summary>
        /// <param name="id">se requiere el identificador para eliminar el cliente de la base de datos</param>
        /// <returns>dentro del objeto que se retorna en la variable Result, devuelve el estado de la eliminacion y en la variable error, si hubieron errores</returns>
        [HttpDelete("EliminarCliente")]
        public Response<bool> EliminarCliente(long id)
        {
            var servicio = crearServicio();
            return servicio.EliminarCliente(id).Result;
        }

        /// <summary>
        /// Buscar un Cliente.
        /// </summary>
        /// <param name="id">se requiere el identificador para obtener el cliente de la base de datos</param>
        /// <returns>dentro del objeto que se retorna en la variable Result, devuelve la informacion del cliente y en la variable error, si hubieron errores</returns>
        [HttpGet("ObtenerClientePorId")]
        public Response<Client> ObtenerClientePorId(long id)
        {
            var servicio = crearServicio();
            return servicio.ObtenerClientePorId(id).Result;
        }

        /// <summary>
        /// Buscar los Clientes.
        /// </summary>
        /// <returns>dentro del objeto que se retorna en la variable Results, devuelve la informacion de los clientes y en la variable error, si hubieron errores</returns>
        [HttpGet("ObtenerTodosLosClientes")]
        public Response<Client> ObtenerTodosLosClientes()
        {
            var servicio = crearServicio();
            return servicio.ObtenerTodosLosClientes().Result;
        }
    }
}
