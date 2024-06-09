using FacturacionHogar.Infraestructure.Context;
using FacturacionHogar.Infraestructure.Interfaces;
using FacturacionHogar.models.domain;

namespace FacturacionHogar.Infraestructure.repositories
{
    public class LeaseReceiptRepository : DefaultEntityFrameworkRepository<LeaseReceipt>, ILeaseReceiptRepository
    {
        public LeaseReceiptRepository(ApiContext context) : base(context)
        {
        }
    }
}
