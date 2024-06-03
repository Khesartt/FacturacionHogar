using FacturacionHogar.models;
using FacturacionHogar.models.domain;
using FacturacionHogar.models.DTO_s;

namespace FacturacionHogar.Interfaces
{
    public interface IParametric
    {
        Task<Response<bool>> CrearParametric(ParametricCreateDto parametric);
        Task<Response<bool>> ActualizarParametric(ParametricUpdateDto parametric);
        Task<Response<bool>> EliminarParametric(long id);
        Task<Response<Service>> ObtenerParametricPorId(long id);
        Task<Response<string>> ObtenerParametricPorKey(string key);
        Task<Response<Service>> ObtenerTodos();
    }
}
