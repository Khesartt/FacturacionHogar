using FacturacionHogar.Application.DataTransferObjects;
using FacturacionHogar.models.enumerators;

namespace FacturacionHogar.Application.Interfaces
{
    public interface ILeaseReceiptService
    {
        public Task<LeaseReceipt> GetLastLeaseReceiptByClientAsync(long clientId, LeaseReceiptType leaseReceiptType);

        public Task SaveLeaseReceiptByClientAsync(LeaseReceipt leaseReceiptDto);

        public Task<LeaseReceiptFile> GenerateLeaseReceiptBase64ByClientAsync(LeaseReceipt leaseReceipt);
    }
}
