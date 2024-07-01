using FacturacionHogar.Infraestructure.Context;
using FacturacionHogar.Infraestructure.Interfaces;
using FacturacionHogar.models.domain;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace FacturacionHogar.Infraestructure.repositories
{
    public class LeaseReceiptRepository : DefaultEntityFrameworkRepository<LeaseReceipt>, ILeaseReceiptRepository
    {
        public LeaseReceiptRepository(ApiContext context) : base(context)
        {
        }

        public async Task<LeaseReceipt?> GetByClientIdAsync(Expression<Func<LeaseReceipt, bool>> predicate)
        {
            return await this._dbSet.Where(predicate).FirstOrDefaultAsync();
        }
    }
}
