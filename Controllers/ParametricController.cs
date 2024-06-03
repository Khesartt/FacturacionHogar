using FacturacionHogar.Context;
using FacturacionHogar.models.DTO_s;
using FacturacionHogar.models;
using FacturacionHogar.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FacturacionHogar.models.domain;

namespace FacturacionHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParametricController : ControllerBase
    {
        ParametricService crearServicio()
        {
            ApiContext db = new();
            ParametricService parametricService = new(db);
            return parametricService;
        }

        /// <summary>
        /// Crear Parametria.
        /// </summary>
        /// <param name="parametric">Los detalles de la nueva variable que se deben proporcionar en el cuerpo de la petición los encuentras en el ejemplo:</param>
        /// <returns>dentro del objeto que se retorna en la variable Result, devuelve el estado de la creacion y en la variable error, si hubieron errores</returns>
        [HttpPost("CrearParametric")]
        public Response<bool> CrearParametric([FromBody] ParametricCreateDto parametric)
        {
            var servicio = crearServicio();
            return servicio.CrearParametric(parametric).Result;
        }

        /// <summary>
        /// actualizar Parametria.
        /// </summary>
        /// <param name="parametric">Los detalles de los campos para actualizar la nueva variable que se deben proporcionar en el cuerpo de la petición los encuentras en el ejemplo:</param>
        /// <returns>dentro del objeto que se retorna en la variable Result, devuelve el estado de la actualizacion y en la variable error, si hubieron errores</returns>
        [HttpPost("ActualizarParametric")]
        public Response<bool> ActualizarParametric([FromBody] ParametricUpdateDto parametric)
        {
            var servicio = crearServicio();
            return servicio.ActualizarParametric(parametric).Result;
        }

        /// <summary>
        /// Eliminar Parametria.
        /// </summary>
        /// <param name="id">se requiere el identificador para eliminar la parametria de la base de datos</param>
        /// <returns>dentro del objeto que se retorna en la variable Result, devuelve el estado de la eliminacion y en la variable error, si hubieron errores</returns>
        [HttpDelete("EliminarParametric")]
        public Response<bool> EliminarParametric(long id)
        {
            var servicio = crearServicio();
            return servicio.EliminarParametric(id).Result;
        }

        /// <summary>
        /// Buscar una Parametria.
        /// </summary>
        /// <param name="id">se requiere el identificador para obtener la parametria de la base de datos</param>
        /// <returns>dentro del objeto que se retorna en la variable Result, devuelve la informacion de la parametria y en la variable error, si hubieron errores</returns>
        [HttpGet("ObtenerParametricPorId")]
        public Response<Service> ObtenerParametricPorId(long id)
        {
            var servicio = crearServicio();
            return servicio.ObtenerParametricPorId(id).Result;
        }
        /// <summary>
        /// Buscar una Parametria.
        /// </summary>
        /// <param name="key">se requiere la palabra que identifica la paremtria para obtener la parametria de la base de datos</param>
        /// <returns>dentro del objeto que se retorna en la variable Result, devuelve la informacion de la parametria y en la variable error, si hubieron errores</returns>
        [HttpGet("ObtenerParametricPorKey")]
        public Response<string> ObtenerParametricPorKey(string key)
        {
            var servicio = crearServicio();
            return servicio.ObtenerParametricPorKey(key).Result;
        }

        /// <summary>
        /// Buscar las Parametrias.
        /// </summary>
        /// <returns>dentro del objeto que se retorna en la variable Results, devuelve la informacion de las parametrias y en la variable error, si hubieron errores</returns>
        [HttpGet("ObtenerTodosLosParametric")]
        public Response<Service> ObtenerTodosLosParametric()
        {
            var servicio = crearServicio();
            return servicio.ObtenerTodos().Result;
        }

    }
}
