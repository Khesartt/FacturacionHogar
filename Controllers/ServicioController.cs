using FacturacionHogar.Context;
using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models.DTO_s;
using FacturacionHogar.models;
using FacturacionHogar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        ServicioService createService()
        {
            ApiContext db = new();
            ServicioService servicioService = new(db);
            return servicioService;
        }

        /// <summary>
        /// Crear servicio.
        /// </summary>
        /// <param name="servicio">Los detalles del nuevo servicio que se deben proporcionar en el cuerpo de la petición los encuentras en el ejemplo:</param>
        /// <returns>dentro del objeto que se retorna en la variable result, devuelve el estado de la creacion y en la variable error, si hubieron errores</returns>
        [HttpPost("Crearservicio")]
        public Response<bool> Crearservicio([FromBody] ServicioCreateDto servicio)
        {
            var ser = createService();
            return ser.Crearservicio(servicio).Result;
        }

        /// <summary>
        /// actualizar servicio.
        /// </summary>
        /// <param name="servicio">Los detalles de los campos para actualizar el servicio que se deben proporcionar en el cuerpo de la petición los encuentras en el ejemplo:</param>
        /// <returns>dentro del objeto que se retorna en la variable result, devuelve el estado de la actualizacion y en la variable error, si hubieron errores</returns>
        [HttpPost("Actualizarservicio")]
        public Response<bool> Actualizarservicio([FromBody] ServicioUpdateDto servicio)
        {
            var ser = createService();
            return ser.Actualizarservicio(servicio).Result;
        }

        /// <summary>
        /// Eliminar servicio.
        /// </summary>
        /// <param name="id">se requiere el identificador para eliminar el servicio de la base de datos</param>
        /// <returns>dentro del objeto que se retorna en la variable result, devuelve el estado de la eliminacion y en la variable error, si hubieron errores</returns>
        [HttpDelete("Eliminarservicio")]
        public Response<bool> Eliminarservicio(long id)
        {
            var ser = createService();
            return ser.Eliminarservicio(id).Result;
        }

        /// <summary>
        /// Buscar un servicio.
        /// </summary>
        /// <param name="id">se requiere el identificador para obtener el servicio de la base de datos</param>
        /// <returns>dentro del objeto que se retorna en la variable result, devuelve la informacion del cliente y en la variable error, si hubieron errores</returns>
        [HttpGet("ObtenerservicioPorId")]
        public Response<Servicio> ObtenerservicioPorId(long id)
        {
            var ser = createService();
            return ser.ObtenerservicioPorId(id).Result;
        }

        /// <summary>
        /// Buscar los servicios.
        /// </summary>
        /// <returns>dentro del objeto que se retorna en la variable results, devuelve la informacion de los servicios y en la variable error, si hubieron errores</returns>
        [HttpGet("ObtenerTodosLosServicios")]
        public Response<Servicio> ObtenerTodosLosServicios()
        {
            var ser = createService();
            return ser.ObtenerTodosLosServicios().Result;
        }

    }
}
