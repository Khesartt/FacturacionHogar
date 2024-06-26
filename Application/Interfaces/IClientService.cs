﻿using FacturacionHogar.Application.DataTransferObjects;

namespace FacturacionHogar.Application.Interfaces
{
    public interface IClientService
    {
        public Task<IEnumerable<Client>> GetClientsAsync();

        public Task<Client> AddClientAsync(InfoClient infoClient);

    }
}
