using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.Interfaces;
using FacturacionHogar.models;

namespace FacturacionHogar.Services
{
    public class ParametricService : IParametric
    {
        public Task<Response<bool>> ActualizarParametric(Parametric parametric)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> CrearParametric(Parametric parametric)
        {
            throw new NotImplementedException();
        }

        public Task<Response<bool>> EliminarParametric(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Parametric>> ObtenerParametricPorId(long id)
        {
            throw new NotImplementedException();
        }

        public Task<Response<Parametric>> ObtenerTodos()
        {
            throw new NotImplementedException();
        }
    }
}
