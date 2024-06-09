namespace FacturacionHogar.Application.DataTransferObjects
{
    public class LeaseReceiptPdf
    {
        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int LeaseAmount { get; set; }

        public string? ReceiptNumber { get; set; }

        public DateTime ReceiptDate { get; set; }

        public string? ClientName { get; set; }

        public string? LeaseAmountInWords { get; set; }

        public string? LeaseDescription { get; set; }

        public string? LeaseAddress { get; set; }
    }
}
