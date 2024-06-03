using FacturacionHogar.models.numerators;

namespace FacturacionHogar.models.domain
{
    public class Service
    {
        public long Id { get; set; }

        public ServiceType ServiceType { get; set; }

        public decimal Value { get; set; }

        public DateTime LastUpdate { get; set; }
    }
}
