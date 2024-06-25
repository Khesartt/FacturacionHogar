namespace FacturacionHogar.Application.DataTransferObjects
{
    public class Client
    {
        public int Id { get; set; }

        public string? Names { get; set; }
    }

    public class InfoClient
    {
        public string? FullName { get; set; }

        public string? Identification { get; set; }

        public string? Phone { get; set; }

    }
}
