using FacturacionHogar.models.enumerators;

namespace FacturacionHogar.Application.DataTransferObjects
{
    public class LeaseReceipt
    {
        public long ReceiptId { get; set; }

        public long IdClient { get; set; }

        public string? ClientName { get; set; }

        public int LeaseAmount { get; set; }

        public string? ReceiptNumber { get; set; }

        public string? LeaseAmountInWords { get; set; }

        public string? LeaseDescription { get; set; }

        public string? LeaseAddress { get; set; }

        public bool ShouldSave { get; set; }

        public DateTime ReceiptDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public  LeaseReceiptType LeaseReceiptType { get; set; }
    }
}
