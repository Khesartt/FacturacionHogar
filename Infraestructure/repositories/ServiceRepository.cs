using FacturacionHogar.Infraestructure.Context;
using FacturacionHogar.Infraestructure.Interfaces;
using FacturacionHogar.models.domain;

namespace FacturacionHogar.Infraestructure.repositories
{
    public class ServiceRepository : DefaultEntityFrameworkRepository<Service>, IServiceRepository
    {
        public ServiceRepository(ApiContext context) : base(context)
        {

        }
    }
}
