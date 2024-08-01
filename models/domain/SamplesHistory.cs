using FacturacionHogar.models.numerators;

namespace FacturacionHogar.models.domain
{
    public class SamplesHistory
    {
        public long Id { get; set; }

        public ServiceType ServiceType { get; set; }

        public DateTime SampleDate { get; set; }

        public decimal Sample { get; set; }

        public long ClientId { get; set; }
    }
}
