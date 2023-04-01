using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models;

namespace FacturacionHogar.Interfaces
{
    public interface IParametric
    {
        Task<Response<Parametric>> ObtenerParametricPorId(long id);
        Task<Response<Parametric>> ObtenerTodos();
        Task<Response<bool>> CrearParametric(Parametric parametric);
        Task<Response<bool>> ActualizarParametric(Parametric parametric);
        Task<Response<bool>> EliminarParametric(long id);

    }
}
