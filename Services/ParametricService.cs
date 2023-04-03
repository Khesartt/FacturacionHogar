using FacturacionHogar.Context;
using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.Interfaces;
using FacturacionHogar.models;
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

            Parametric parametricToUpdate = await db.parametric.FindAsync(parametric.id);
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
                    response.result = true;
                }
                else
                {
                    response.result = false;
                    response.message = "no se encontro la variable [ParametricService => ActualizarParametric]";
                    response.existError = true;
                }

            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ParametricService => ActualizarParametric]";
            }
            return response;
        }

        public async Task<Response<bool>> CrearParametric(ParametricCreateDto parametric)
        {
            Response<bool> response = new();
            try
            {
                Parametric parametricToCreate =
                    new Parametric((string.IsNullOrEmpty(parametric.tipo) ? "no registra tipo" : parametric.tipo),
                                   (string.IsNullOrEmpty(parametric.valor) ? "no registra valor" : parametric.valor));

                await db.parametric.AddAsync(parametricToCreate);
                await db.SaveChangesAsync();
                response.result = true;
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ParametricService => CrearParametric]";
            }
            return response;
        }

        public async Task<Response<bool>> EliminarParametric(long id)
        {
            Response<bool> response = new();
            try
            {
                Parametric parametricToDelete = await db.parametric.FindAsync(id);
                if (parametricToDelete != null)
                {
                    db.Remove(parametricToDelete);
                    await db.SaveChangesAsync();
                    response.result = true;
                }
                else
                {
                    response.message = "no se encontro ninguna variable con ese id [ParametricService => EliminarParametric]";
                    response.result = false;
                    response.existError = true;
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ParametricService => EliminarParametric]";
            }
            return response;
        }

        public async Task<Response<Parametric>> ObtenerParametricPorId(long id)
        {
            Response<Parametric> response = new();

            try
            {
                Parametric parametric = await db.parametric.FindAsync(id);
                if (parametric != null) response.result = parametric;
                else
                {
                    response.message = "no se encontro ninguna varaiable con ese id [ParametricService => ObtenerParametricPorId]";
                    response.result = null;
                    response.existError = true;
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ParametricService => ObtenerParametricPorId]";
            }
            return response;
        }

        public async Task<Response<Parametric>> ObtenerTodos()
        {
            Response<Parametric> response = new();
            try
            {
                response.results = await db.parametric.ToListAsync();
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ParametricService => ObtenerTodos]";
            }
            return response;
        }
    }
}
