using FacturacionHogar.Context;
using FacturacionHogar.Dominio.modelos;
using FacturacionHogar.Interfaces;
using FacturacionHogar.models;
using FacturacionHogar.models.DTO_s;
using Microsoft.EntityFrameworkCore;
using System.Net.Mail;

namespace FacturacionHogar.Services
{
    public class ClienteService : ICliente
    {

        private ApiContext db;

        public ClienteService(ApiContext _db)
        {
            db = _db;
        }
        public async Task<Response<bool>> ActualizarCliente(ClienteUpdateDto cliente)
        {
            Response<bool> response = new();

            try
            {
                var direccionCorreo = new MailAddress((string.IsNullOrEmpty(cliente.correo) ? "" : cliente.correo));

                #region actualizarCliente
                try
                {
                    Cliente clienteToUpdate = await db.cliente.FindAsync(cliente.id);

                    if (clienteToUpdate != null)
                    {
                        clienteToUpdate.id = clienteToUpdate.id;
                        clienteToUpdate.nombres = string.IsNullOrEmpty(cliente.nombres) ? clienteToUpdate.nombres : cliente.nombres;
                        clienteToUpdate.cedula = string.IsNullOrEmpty(cliente.cedula) ? clienteToUpdate.cedula : cliente.cedula;
                        clienteToUpdate.celular = string.IsNullOrEmpty(cliente.celular) ? clienteToUpdate.celular : cliente.celular;
                        clienteToUpdate.correo = string.IsNullOrEmpty(cliente.correo) ? clienteToUpdate.correo : cliente.correo;
                        clienteToUpdate.fechaActualizacion = DateTime.Now;
                        await db.SaveChangesAsync();
                        response.result = true;
                    }
                    else
                    {
                        response.result = false;
                        response.message = "no se encontro el cliente [ClienteService => ActualizarCliente]";
                        response.existError = true;
                    }
                }
                catch (Exception ex)
                {
                    response = new Response<bool>(ex);
                    response.message = "error no controlado [ClienteService => ActualizarCliente]";
                }
                #endregion
            }
            catch (Exception ex)
            {
                response = new Response<bool>(ex);
                response.message = "el correo no tiene el formato correcto [ClienteService => ActualizarCliente]";
            }
            return response;
        }

        public async Task<Response<bool>> CrearCliente(ClienteCreateDto cliente)
        {
            Response<bool> response = new();

            try
            {
                var direccionCorreo = new MailAddress((string.IsNullOrEmpty(cliente.correo) ? "" : cliente.correo));
                #region CrearCliente
                try
                {
                    Cliente clienteToCreate =
                        new Cliente(
                            (string.IsNullOrEmpty(cliente.nombres) ? "no registra nombre" : cliente.nombres),
                            (string.IsNullOrEmpty(cliente.cedula) ? "no registra cedula" : cliente.cedula),
                            (string.IsNullOrEmpty(cliente.celular) ? "no registra celular" : cliente.celular),
                            direccionCorreo.Address);

                    await db.cliente.AddAsync(clienteToCreate);
                    await db.SaveChangesAsync();
                    response.result = true;
                }
                catch (Exception ex)
                {
                    response = new Response<bool>(ex);
                    response.message = "error no controlado [ClienteService => CrearCliente]";
                }
                #endregion
            }
            catch (Exception ex)
            {
                response = new Response<bool>(ex);
                response.message = "el correo no tiene el formato correcto [ClienteService => CrearCliente]";
            }
            return response;
        }

        public async Task<Response<bool>> EliminarCliente(long id)
        {
            Response<bool> response = new();
            try
            {
                Cliente clienteToDelete = await db.cliente.FindAsync(id);
                if (clienteToDelete != null)
                {
                    db.Remove(clienteToDelete);
                    await db.SaveChangesAsync();
                    response.result = true;
                }
                else
                {
                    response.message = "no se encontro ningun cliente con ese id [ClienteService => EliminarCliente]";
                    response.result = false;
                    response.existError = true;
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ClienteService => EliminarCliente]";
            }
            return response;
        }

        public async Task<Response<Cliente>> ObtenerClientePorId(long id)
        {
            Response<Cliente> response = new();

            try
            {
                Cliente cliente = await db.cliente.FindAsync(id);
                if (cliente != null) response.result = cliente;
                else
                {
                    response.message = "no se encontro ningun cliente con ese id [ClienteService => ObtenerClientePorId]";
                    response.result = null;
                    response.existError = true;
                }
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ClienteService => ObtenerClientePorId]";
            }
            return response;
        }

        public async Task<Response<Cliente>> ObtenerTodosLosClientes()
        {
            Response<Cliente> response = new();
            try
            {
                response.results = await db.cliente.ToListAsync();
            }
            catch (Exception ex)
            {
                response = new(ex);
                response.message = "error no controlado [ClienteService => ObtenerTodosLosClientes]";
            }
            return response;
        }
    }
}
