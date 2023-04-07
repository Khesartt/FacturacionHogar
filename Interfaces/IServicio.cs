using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models;
using FacturacionHogar.models.DTO_s;

namespace FacturacionHogar.Interfaces
{
    public interface IServicio
    {
        Task<Response<Servicio>> ObtenerservicioPorId(long id);
        Task<Response<Servicio>> ObtenerTodosLosServicios();
        Task<Response<bool>> Crearservicio(ServicioCreateDto servicio);
        Task<Response<bool>> Actualizarservicio(ServicioUpdateDto servicio);
        Task<Response<bool>> Eliminarservicio(long id);

    }
}
