using FacturacionHogar.Context;
using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.Interfaces;
using FacturacionHogar.models;
using FacturacionHogar.models.DTO_s;
using Microsoft.EntityFrameworkCore;

namespace FacturacionHogar.Services
{
    public class ServicioService : IServicio
    {
        private ApiContext db;

        public ServicioService(ApiContext _db)
        {
            db = _db;
        }

        public async Task<Response<bool>> Actualizarservicio(ServicioUpdateDto servicio)
        {
            Response<bool> response = new();

            try
            {
                Cliente cliente = await db.cliente.FindAsync(servicio.idCliente);
                Parametric parametric = await db.parametric.FindAsync(servicio.idParametric);
                if (cliente == null) throw new Exception("el cliente no fue encontrado en base de datos");
                else if (parametric == null) throw new Exception("el valor parametrico no fue encontrado en base de datos");
                else
                {
                    Servicio servicioToUpdate = await db.servicio.FindAsync(servicio.id);
                    if (servicioToUpdate != null && servicio.medicionActual != null)
                    {
                        servicioToUpdate.id = servicioToUpdate.id;
                        servicioToUpdate.medicionBackUp = servicioToUpdate.medicionAnterior;
                        servicioToUpdate.medicionAnterior = servicioToUpdate.medicionActual;
                        servicioToUpdate.medicionActual = servicio.medicionActual;
                        servicioToUpdate.idCliente = servicioToUpdate.idCliente;
                        servicioToUpdate.idParametric = servicioToUpdate.idParametric;
                        servicioToUpdate.fechaActualizacion = DateTime.Now;
                        await db.SaveChangesAsync();
                        response.result = true;
                    }
                    else
                    {
                        response.result = false;
                        response.message = "no se encontro el servicio [ServicioService => Actualizarservicio]";
                        response.existError = true;
                    }
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado en error no controlado [ServicioService => Actualizarservicio]";
            }
            return response;
        }

        public async Task<Response<bool>> Crearservicio(ServicioCreateDto servicio)
        {
            Response<bool> response = new();
            try
            {
                Cliente cliente = await db.cliente.FindAsync(servicio.idCliente);
                Parametric parametric = await db.parametric.FindAsync(servicio.idParametric);
                if (cliente == null) throw new Exception("el cliente no fue encontrado en base de datos");
                else if (parametric == null) throw new Exception("el valor parametrico no fue encontrado en base de datos");
                else
                {
                    if (servicio.medicionActual != null && servicio.medicionAnterior != null)
                    {
                        Servicio servicioToCreate = new(servicio.medicionAnterior, servicio.medicionActual, servicio.idCliente, servicio.idParametric);
                        await db.AddAsync(servicioToCreate);
                        await db.SaveChangesAsync();
                        response.result = true;
                    }
                    else
                    {
                        response.message = "los campos no puede ser vacios o nulos";
                        response.existError = true;
                        response.result = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado en error no controlado [ServicioService => Crearservicio]";
            }
            return response;
        }

        public async Task<Response<bool>> Eliminarservicio(long id)
        {
            Response<bool> response = new();
            try
            {
                Servicio servicioToDelete = await db.servicio.FindAsync(id);
                if (servicioToDelete != null)
                {
                    db.Remove(servicioToDelete);
                    await db.SaveChangesAsync();
                    response.result = true;
                }
                else
                {
                    response.message = "no se encontro ningun servicio con ese id [ServicioService => Eliminarservicio]";
                    response.result = false;
                    response.existError = true;
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ServicioService => Eliminarservicio]";
            }
            return response;
        }

        public async Task<Response<Servicio>> ObtenerservicioPorId(long id)
        {
            Response<Servicio> response = new();

            try
            {
                Servicio servicio = await db.servicio.FindAsync(id);
                if (servicio != null) response.result = servicio;
                else
                {
                    response.message = "no se encontro ningun servicio con ese id [ServicioService => ObtenerservicioPorId]";
                    response.result = null;
                    response.existError = true;
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ServicioService => ObtenerClientePorId]";
            }
            return response;
        }

        public async Task<Response<Servicio>> ObtenerTodosLosServicios()
        {
            Response<Servicio> response = new();
            try
            {
                response.results = await db.servicio.ToListAsync();
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ServicioService => ObtenerTodosLosservicios]";
            }
            return response;
        }
    }
}
