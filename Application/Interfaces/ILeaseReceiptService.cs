using FacturacionHogar.Application.DataTransferObjects;

namespace FacturacionHogar.Application.Interfaces
{
    public interface ILeaseReceiptService
    {
        public Task<LeaseReceipt> GetLastLeaseReceiptByClientAsync(long clientId);
    }
}
