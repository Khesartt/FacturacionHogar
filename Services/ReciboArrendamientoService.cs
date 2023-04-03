using FacturacionHogar.Context;
using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.Interfaces;
using FacturacionHogar.models;
using FacturacionHogar.models.DTO_s;
using Microsoft.EntityFrameworkCore;

namespace FacturacionHogar.Services
{
    public class ReciboArrendamientoService : IReciboArrendamiento
    {
        private ApiContext db;

        public ReciboArrendamientoService(ApiContext _db)
        {
            db = _db;
        }

        public async Task<Response<bool>> ActualizarRecibo(ReciboArrendamientoUpdateDto recibo)
        {
            Response<bool> response = new();
            try
            {
                ReciboArrendamiento reciboArrendamientoToUpdate = await db.reciboArrendamiento.FindAsync(recibo.id);
                if (reciboArrendamientoToUpdate != null)
                {
                    reciboArrendamientoToUpdate.id = reciboArrendamientoToUpdate.id;
                    reciboArrendamientoToUpdate.valorArrendamiento = (string.IsNullOrEmpty(recibo.valorArrendamiento) ? reciboArrendamientoToUpdate.valorArrendamiento : recibo.valorArrendamiento);
                    reciboArrendamientoToUpdate.numeroRecibo = (string.IsNullOrEmpty(recibo.numeroRecibo) ? reciboArrendamientoToUpdate.numeroRecibo : recibo.numeroRecibo);
                    reciboArrendamientoToUpdate.fechaRecibo = (string.IsNullOrEmpty(recibo.fechaRecibo.ToString()) ? reciboArrendamientoToUpdate.fechaRecibo : recibo.fechaRecibo);
                    reciboArrendamientoToUpdate.nombreCliente = (string.IsNullOrEmpty(recibo.nombreCliente) ? reciboArrendamientoToUpdate.nombreCliente : recibo.nombreCliente);
                    reciboArrendamientoToUpdate.valorArrendamientoLetra = (string.IsNullOrEmpty(recibo.valorArrendamientoLetra) ? reciboArrendamientoToUpdate.valorArrendamientoLetra : recibo.valorArrendamientoLetra);
                    reciboArrendamientoToUpdate.descripcionArrendamiento = (string.IsNullOrEmpty(recibo.descripcionArrendamiento) ? reciboArrendamientoToUpdate.descripcionArrendamiento : recibo.descripcionArrendamiento);
                    reciboArrendamientoToUpdate.direccionArrendamiento = (string.IsNullOrEmpty(recibo.direccionArrendamiento) ? reciboArrendamientoToUpdate.direccionArrendamiento : recibo.direccionArrendamiento);
                    reciboArrendamientoToUpdate.fechaInicial = (string.IsNullOrEmpty(recibo.fechaInicial.ToString()) ? reciboArrendamientoToUpdate.fechaInicial : recibo.fechaInicial);
                    reciboArrendamientoToUpdate.fechaFinal = (string.IsNullOrEmpty(recibo.fechaFinal.ToString()) ? reciboArrendamientoToUpdate.fechaFinal : recibo.fechaFinal);
                    reciboArrendamientoToUpdate.idCliente = (recibo.idCliente == -1 ? reciboArrendamientoToUpdate.idCliente : recibo.idCliente);

                    db.Update(reciboArrendamientoToUpdate);
                    await db.SaveChangesAsync();
                    response.result = true;
                }
                else
                {
                    response.message = "no se encontro dicho recibo [ReciboArrendamientoService => ActualizarRecibo]";
                    response.result = false;
                    response.existError = true;
                }

            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ReciboArrendamientoService => ActualizarRecibo]";
            }

            return response;
        }

        public async Task<Response<bool>> CrearRecibo(ReciboArrendamientoCreateDto recibo)
        {
            Response<bool> response = new();

            try
            {
                long idClienteNa = await db.cliente.Where(x => x.nombres == "Na").Select(x => x.id).FirstOrDefaultAsync();

                ReciboArrendamiento reciboArrendamiento = new ReciboArrendamiento(
                    ((recibo.idCliente == -1) ? idClienteNa : recibo.idCliente),
                    (string.IsNullOrEmpty(recibo.valorArrendamiento) ? "sin valor" : recibo.valorArrendamiento),
                    (string.IsNullOrEmpty(recibo.numeroRecibo) ? "sin numeroRecibo" : recibo.numeroRecibo),
                    (string.IsNullOrEmpty(recibo.nombreCliente) ? "sin nombreCliente" : recibo.nombreCliente),
                    (string.IsNullOrEmpty(recibo.valorArrendamientoLetra) ? "sin valorArrendamientoLetra" : recibo.valorArrendamientoLetra),
                    (string.IsNullOrEmpty(recibo.descripcionArrendamiento) ? "sin descripcionArrendamiento" : recibo.descripcionArrendamiento),
                    (string.IsNullOrEmpty(recibo.direccionArrendamiento) ? "sin direccionArrendamiento" : recibo.direccionArrendamiento),
                    (string.IsNullOrEmpty(recibo.fechaRecibo.ToString()) ? new DateTime(1700, 01, 01) : recibo.fechaRecibo),
                    (string.IsNullOrEmpty(recibo.fechaFinal.ToString()) ? new DateTime(1700, 01, 01) : recibo.fechaFinal),
                    (string.IsNullOrEmpty(recibo.fechaInicial.ToString()) ? new DateTime(1700, 01, 01) : recibo.fechaInicial)
                    );
                await db.AddAsync(reciboArrendamiento);
                await db.SaveChangesAsync();

                response.result = true;
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ReciboArrendamientoService => CrearRecibo]";
            }
            return response;
        }

        public async Task<Response<bool>> EliminarRecibo(long id)
        {
            Response<bool> response = new();
            try
            {
                ReciboArrendamiento reciboArrendamiento = await db.reciboArrendamiento.FindAsync(id);

                if (reciboArrendamiento != null)
                {
                    db.Remove(reciboArrendamiento);
                    await db.SaveChangesAsync();
                    response.result = true;
                }
                else
                {
                    response.message = "no se encontro dicho recibo [ReciboArrendamientoService => EliminarRecibo]";
                    response.result = false;
                    response.existError = true;

                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ReciboArrendamientoService => EliminarRecibo]";
            }
            return response;
        }

        public async Task<Response<ReciboArrendamiento>> ObtenerReciboPorId(long id)
        {
            Response<ReciboArrendamiento> response = new();

            try
            {
                ReciboArrendamiento reciboArrendamiento = await db.reciboArrendamiento.FindAsync(id);
                if (reciboArrendamiento != null) response.result = reciboArrendamiento;
                else
                {
                    response.message = "no se encontro ningun cliente con ese id [ReciboArrendamientoService => ObtenerReciboPorId]";
                    response.result = null;
                    response.existError = true;
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ReciboArrendamientoService => ObtenerReciboPorId]";
            }
            return response;
        }

        public async Task<Response<ReciboArrendamiento>> ObtenerTodosLosRecibos()
        {
            Response<ReciboArrendamiento> response = new();
            try
            {
                response.results = await db.reciboArrendamiento.ToListAsync();
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ReciboArrendamientoService => ObtenerTodosLosRecibos]";
            }
            return response;
        }
    }
}
