using FacturacionHogar.models.domain;
using System.Linq.Expressions;

namespace FacturacionHogar.Infraestructure.Interfaces
{
    public interface ILeaseReceiptRepository : IDefaultRepository<LeaseReceipt>
    {
        public Task<LeaseReceipt?> GetByClientIdAndLeaseTypeAsync(Expression<Func<LeaseReceipt, bool>> predicate);
    }
}
