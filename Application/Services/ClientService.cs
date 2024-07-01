using AutoMapper;
using FacturacionHogar.Application.DataTransferObjects;
using FacturacionHogar.Application.Interfaces;
using FacturacionHogar.Infraestructure.Interfaces;
using domain = FacturacionHogar.models.domain;

namespace FacturacionHogar.Application.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public ClientService(IClientRepository clientRepository, IMapper mapper)
        {
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<Client>> GetClientsAsync()
        {
            var clients = await this.clientRepository.GetAllAsync();

            return clients.Select(client => this.mapper.Map<Client>(client)).ToList();
        }

        public async Task<Client> AddClientAsync(InfoClient infoClient)
        {
            domain.Client client = this.mapper.Map<domain.Client>(infoClient);

            client.SetDefaultExtraData();
            client.NormalizeFullName();

            return this.mapper.Map<Client>(await this.clientRepository.AddAsync(client));
        }
    }
}
