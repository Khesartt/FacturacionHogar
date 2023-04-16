using FacturacionHogar.Context;
using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models.DTO_s;
using FacturacionHogar.models;
using FacturacionHogar.Services;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReciboArrendamietoController : ControllerBase
    {
        ReciboArrendamientoService crearServicio()
        {
            ApiContext db = new();
            ReciboArrendamientoService clienteService = new(db);
            return clienteService;
        }

        /// <summary>
        /// Crear recibo de arriendo.
        /// </summary>
        /// <param name="recibo">Los detalles del nuevo recibo de arriendo que se deben proporcionar en el cuerpo de la petición los encuentras en el ejemplo:</param>
        /// <returns>dentro del objeto que se retorna en la variable result, devuelve el estado de la creacion y en la variable error, si hubieron errores</returns>
        [HttpPost("CrearRecibo")]
        public Response<bool> CrearRecibo([FromBody] ReciboArrendamientoCreateDto recibo)
        {
            var servicio = crearServicio();
            return servicio.CrearRecibo(recibo).Result;
        }

        /// <summary>
        /// actualizar recibo de arriendo.
        /// </summary>
        /// <param name="cliente">Los detalles de los campos para actualizar el recibo de arriendo que se deben proporcionar en el cuerpo de la petición los encuentras en el ejemplo:</param>
        /// <returns>dentro del objeto que se retorna en la variable result, devuelve el estado de la actualizacion y en la variable error, si hubieron errores</returns>
        [HttpPost("ActualizarRecibo")]
        public Response<bool> ActualizarRecibo([FromBody] ReciboArrendamientoUpdateDto recibo)
        {
            var servicio = crearServicio();
            return servicio.ActualizarRecibo(recibo).Result;
        }

        /// <summary>
        /// Eliminar recibo de arriendo.
        /// </summary>
        /// <param name="id">se requiere el identificador para eliminar el recibo de arriendo de la base de datos</param>
        /// <returns>dentro del objeto que se retorna en la variable result, devuelve el estado de la eliminacion y en la variable error, si hubieron errores</returns>
        [HttpDelete("EliminarRecibo")]
        public Response<bool> EliminarRecibo(long id)
        {
            var servicio = crearServicio();
            return servicio.EliminarRecibo(id).Result;
        }

        /// <summary>
        /// Buscar un recibo de arriendo.
        /// </summary>
        /// <param name="id">se requiere el identificador para obtener el recibo de arriendo de la base de datos</param>
        /// <returns>dentro del objeto que se retorna en la variable result, devuelve la informacion del recibo y en la variable error, si hubieron errores</returns>
        [HttpGet("ObtenerReciboPorId")]
        public Response<ReciboArrendamiento> ObtenerReciboPorId(long id)
        {
            var servicio = crearServicio();
            return servicio.ObtenerReciboPorId(id).Result;
        }


        /// <summary>
        /// Buscar un recibo de arriendo.
        /// </summary>
        /// <param name="id">se requiere el identificador para obtener los recibos de arriendo de la base de datos</param>
        /// <returns>dentro del objeto que se retorna en la variable result, devuelve la informacion de los recibos y en la variable error, si hubieron errores</returns>
        [HttpGet("ObtenerReciboPorIdCliente")]
        public Response<ReciboArrendamiento> ObtenerReciboPorIdCliente(long id)
        {
            var servicio = crearServicio();
            return servicio.ObtenerReciboPorIdCliente(id).Result;
        }


        /// <summary>
        /// Buscar los recibo de arriendo.
        /// </summary>
        /// <returns>dentro del objeto que se retorna en la variable results, devuelve la informacion de los clientes y en la variable error, si hubieron errores</returns>
        [HttpGet("ObtenerTodosLosRecibos")]
        public Response<ReciboArrendamiento> ObtenerTodosLosRecibos()
        {
            var servicio = crearServicio();
            return servicio.ObtenerTodosLosRecibos().Result;
        }

    }
}
