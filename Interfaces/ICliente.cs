using FacturacionHogar.models;
using FacturacionHogar.models.domain;
using FacturacionHogar.models.DTO_s;

namespace FacturacionHogar.Interfaces
{
    public interface ICliente
    {
        Task<Response<Client>> ObtenerClientePorId(long id);
        Task<Response<Client>> ObtenerTodosLosClientes();
        Task<Response<bool>> CrearCliente(ClienteCreateDto cliente);
        Task<Response<bool>> ActualizarCliente(ClienteUpdateDto cliente);
        Task<Response<bool>> EliminarCliente(long id);
    }
}
