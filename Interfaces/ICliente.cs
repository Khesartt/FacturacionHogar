using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models;
using FacturacionHogar.models.DTO_s;

namespace FacturacionHogar.Interfaces
{
    public interface ICliente
    {
        Task<Response<Cliente>> ObtenerClientePorId(long id);
        Task<Response<Cliente>> ObtenerTodosLosClientes();
        Task<Response<bool>> CrearCliente(ClienteCreateDto cliente);
        Task<Response<bool>> ActualizarCliente(ClienteUpdateDto cliente);
        Task<Response<bool>> EliminarCliente(long id);
    }
}
