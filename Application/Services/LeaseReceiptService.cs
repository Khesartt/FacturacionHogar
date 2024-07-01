using AutoMapper;
using FacturacionHogar.Application.DataTransferObjects;
using FacturacionHogar.Application.Interfaces;
using FacturacionHogar.Infraestructure.Interfaces;
namespace FacturacionHogar.Application.Services
{
    public class LeaseReceiptService : ILeaseReceiptService
    {
        private readonly ILeaseReceiptRepository leaseReceiptRepository;
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public LeaseReceiptService(ILeaseReceiptRepository leaseReceiptRepository, IClientRepository clientRepository, IMapper mapper)
        {
            this.leaseReceiptRepository = leaseReceiptRepository;
            this.clientRepository = clientRepository;
            this.mapper = mapper;
        }

        public async Task<LeaseReceipt> GetLastLeaseReceiptByClientAsync(long clientId)
        {
            var leaseReceiptByDomain = await this.leaseReceiptRepository.GetByClientIdAsync(lease => lease.IdClient == clientId)
                                        ?? throw new KeyNotFoundException($"LeaseReceipt for client ID {clientId} not found.");

            var client = await this.clientRepository.GetByIdAsync(clientId)
                         ?? throw new KeyNotFoundException($"Client with ID {clientId} not found.");

            var leaseReceipt = this.mapper.Map<LeaseReceipt>(leaseReceiptByDomain);
            leaseReceipt.FullNameClient = client.FullName;

            return leaseReceipt;
        }
    }
}
