using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models;

namespace FacturacionHogar.Interfaces
{
    public interface IReciboArrendamiento
    {
        Task<Response<ReciboArrendamiento>> ObtenerReciboPorId(long id);
        Task<Response<ReciboArrendamiento>> ObtenerTodosLosRecibos();
        Task<Response<bool>> CrearRecibo(ReciboArrendamiento recibo);
        Task<Response<bool>> ActualizarRecibo(ReciboArrendamiento recibo);
        Task<Response<bool>> EliminarRecibo(long id);



    }
}
