using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.models;

namespace FacturacionHogar.Interfaces
{
    public interface ICliente
    {
        Task<Response<Cliente>> ObtenerClientePorId(long id);
        Task<Response<Cliente>> ObtenerTodosLosClientes();
        Task<Response<bool>> CrearCliente(Cliente cliente);
        Task<Response<bool>> ActualizarCliente(Cliente cliente);
        Task<Response<bool>> EliminarCliente(long id);
    }
}
