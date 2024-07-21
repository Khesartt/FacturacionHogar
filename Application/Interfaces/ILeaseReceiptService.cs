using FacturacionHogar.Application.DataTransferObjects;

namespace FacturacionHogar.Application.Interfaces
{
    public interface ILeaseReceiptService
    {
        public Task<LeaseReceipt> GetLastLeaseReceiptByClientAsync(long clientId);

        public Task SaveLeaseReceiptByClientAsync(LeaseReceipt leaseReceiptDto);

        public Task<LeaseReceiptFile> GenerateLeaseReceiptBase64ByClientAsync(LeaseReceipt leaseReceipt);
    }
}
