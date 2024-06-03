namespace FacturacionHogar.models.domain
{
    public class Client
    {
        public long Id { get; set; }
        public string? FullName { get; set; }
        public string? Identification { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
