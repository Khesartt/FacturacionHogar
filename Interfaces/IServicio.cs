using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models;

namespace FacturacionHogar.Interfaces
{
    public interface IServicio
    {
        Task<Response<Servicio>> ObtenerservicioPorId(long id);
        Task<Response<Servicio>> ObtenerTodosLosservicios();
        Task<Response<bool>> Crearservicio(Servicio servicio);
        Task<Response<bool>> Actualizarservicio(Servicio servicio);
        Task<Response<bool>> Eliminarservicio(long id);

    }
}
