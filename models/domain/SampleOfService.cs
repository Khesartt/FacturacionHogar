namespace FacturacionHogar.models.domain
{
    public class SampleOfService
    {
        public long Id { get; set; }
        public decimal LastSample { get; set; }
        public decimal CurrentSample { get; set; }
        public long IdClient { get; set; }
        public long IdParametric { get; set; }
        public DateTime CurentDate { get; set; }
    }

}
