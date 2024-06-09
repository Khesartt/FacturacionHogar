using FacturacionHogar.Infraestructure.Context;
using FacturacionHogar.Infraestructure.Interfaces;
using FacturacionHogar.models.domain;

namespace FacturacionHogar.Infraestructure.repositories
{
    public class SamplesHistoryRepository : DefaultEntityFrameworkRepository<SamplesHistory>, ISamplesHistoryRepository
    {
        public SamplesHistoryRepository(ApiContext context) : base(context)
        {
        }
    }
}
