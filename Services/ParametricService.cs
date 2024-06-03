using FacturacionHogar.Context;
using FacturacionHogar.Interfaces;
using FacturacionHogar.models;
using FacturacionHogar.models.domain;
using FacturacionHogar.models.DTO_s;
using Microsoft.EntityFrameworkCore;

namespace FacturacionHogar.Services
{
    public class ParametricService : IParametric
    {
        private ApiContext db;

        public ParametricService(ApiContext _db)
        {
            db = _db;
        }

        public async Task<Response<bool>> ActualizarParametric(ParametricUpdateDto parametric)
        {
            Response<bool> response = new();

            Service parametricToUpdate = await db.parametric.FindAsync(parametric.id);
            try
            {
                if (parametricToUpdate != null)
                {
                    parametricToUpdate.id = parametricToUpdate.id;
                    parametricToUpdate.tipo = string.IsNullOrEmpty(parametric.tipo) ? parametricToUpdate.tipo : parametric.tipo;
                    parametricToUpdate.valor = string.IsNullOrEmpty(parametric.valor) ? parametricToUpdate.valor : parametric.valor;
                    parametricToUpdate.fechaActualizacion = DateTime.Now;

                    db.Update(parametricToUpdate);
                    await db.SaveChangesAsync();
                    response.Result = true;
                }
                else
                {
                    response.Result = false;
                    response.Message = "no se encontro la variable [ParametricService => ActualizarParametric]";
                    response.existError = true;
                }

            }
            catch (Exception ex)
            {
                response = new(ex);
                response.Message = "error no controlado [ParametricService => ActualizarParametric]";
            }
            return response;
        }

        public async Task<Response<bool>> CrearParametric(ParametricCreateDto parametric)
        {
            Response<bool> response = new();
            try
            {
                Service parametricToCreate =
                    new Service((string.IsNullOrEmpty(parametric.tipo) ? "no registra tipo" : parametric.tipo),
                                   (string.IsNullOrEmpty(parametric.valor) ? "no registra valor" : parametric.valor));

                await db.parametric.AddAsync(parametricToCreate);
                await db.SaveChangesAsync();
                response.Result = true;
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.Message = "error no controlado [ParametricService => CrearParametric]";
            }
            return response;
        }

        public async Task<Response<bool>> EliminarParametric(long id)
        {
            Response<bool> response = new();
            try
            {
                Service parametricToDelete = await db.parametric.FindAsync(id);
                if (parametricToDelete != null)
                {
                    db.Remove(parametricToDelete);
                    await db.SaveChangesAsync();
                    response.Result = true;
                }
                else
                {
                    response.Message = "no se encontro ninguna variable con ese id [ParametricService => EliminarParametric]";
                    response.Result = false;
                    response.existError = true;
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.Message = "error no controlado [ParametricService => EliminarParametric]";
            }
            return response;
        }

        public async Task<Response<Service>> ObtenerParametricPorId(long id)
        {
            Response<Service> response = new();

            try
            {
                Service parametric = await db.parametric.FindAsync(id);
                if (parametric != null) response.Result = parametric;
                else
                {
                    response.Message = "no se encontro ninguna varaiable con ese id [ParametricService => ObtenerParametricPorId]";
                    response.Result = null;
                    response.existError = true;
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.Message = "error no controlado [ParametricService => ObtenerParametricPorId]";
            }
            return response;
        }

        public Task<Response<string>> ObtenerParametricPorKey(string key)
        {
            Response<string> response = new();

            try
            {
                string parametric = db.parametric.Where(x => x.tipo.Equals(key)).Select(x => x.valor).FirstOrDefault();
                if (parametric != null)
                {
                    response.Result = parametric;
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.Message = "error no controlado [ParametricService => ObtenerParametricPorKey]";
            }
            return Task.FromResult(response);
        }

        public async Task<Response<Service>> ObtenerTodos()
        {
            Response<Service> response = new();
            try
            {
                response.Results = await db.parametric.ToListAsync();
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.Message = "error no controlado [ParametricService => ObtenerTodos]";
            }
            return response;
        }
    }
}
