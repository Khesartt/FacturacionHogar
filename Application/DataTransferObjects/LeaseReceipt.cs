namespace FacturacionHogar.Application.DataTransferObjects
{
    public class LeaseReceipt
    {
        public long ReceiptId { get; set; }

        public long ClientId { get; set; }

        public string? FullNameClient { get; set; }

        public string? LeaseAmount { get; set; }

        public string? ReceiptNumber { get; set; }

        public string? LeaseAmountInWords { get; set; }

        public string? LeaseDescription { get; set; }

        public string? LeaseAddress { get; set; }

        public DateTime ReceiptDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }
    }
}
