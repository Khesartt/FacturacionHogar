using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models;
using FacturacionHogar.models.DTO_s;

namespace FacturacionHogar.Interfaces
{
    public interface IReciboArrendamiento
    {
        Task<Response<ReciboArrendamiento>> ObtenerReciboPorId(long id);
        Task<Response<ReciboArrendamiento>> ObtenerTodosLosRecibos();
        Task<Response<bool>> CrearRecibo(ReciboArrendamientoCreateDto recibo);
        Task<Response<bool>> ActualizarRecibo(ReciboArrendamientoUpdateDto recibo);
        Task<Response<bool>> EliminarRecibo(long id);
    }
}
