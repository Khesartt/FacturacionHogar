using FacturacionHogar.models.enumerators;

namespace FacturacionHogar.models.domain
{
    public class LeaseReceipt
    {
        public long Id { get; set; }
        public long IdClient { get; set; }
        public int LeaseAmount { get; set; }
        public string? ReceiptNumber { get; set; }
        public string? LeaseAmountInWords { get; set; }
        public string? LeaseDescription { get; set; }
        public string? LeaseAddress { get; set; }
        public DateTime ReceiptDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime LastUpdated { get; set; }
        public LeaseReceiptType LeaseReceiptType { get; set; }
    }
}
