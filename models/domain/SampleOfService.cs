namespace FacturacionHogar.models.domain
{
    public class SampleOfService
    {
        public long Id { get; set; }
        public decimal LastSample { get; set; }
        public decimal CurrentSample { get; set; }
        public long IdClient { get; set; }
        public long IdService { get; set; }
        public DateTime CurrentDate { get; set; }
    }

}
