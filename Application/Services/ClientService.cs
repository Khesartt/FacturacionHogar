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
            IEnumerable<domain.Client> clients = await this.clientRepository.GetAllAsync();

            List<Client> result = clients.Select(client => this.mapper.Map<Client>(client)).ToList();

            return result;
        }
    }
}
