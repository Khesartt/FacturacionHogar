using System.Text.Json.Serialization;

namespace FacturacionHogar.Application.DataTransferObjects
{
    public class LeaseReceiptPdf
    {
        /// <summary>
        /// 
        /// </summary>
        /// <example>2024-08-09</example>
        [JsonPropertyName("fecha desde")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>2024-07-10</example>
        [JsonPropertyName("fecha hasta")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>750000</example>
        [JsonPropertyName("cantidad de dinero en numero")]
        public int LeaseAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>26</example>
        [JsonPropertyName("numero de recibo")]
        public string? ReceiptNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>2024-06-10</example>
        [JsonPropertyName("fecha del recibo")]
        public DateTime ReceiptDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>MARIA JOSE CALDAS</example>
        [JsonPropertyName("recibi de")]
        public string? ClientName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>SETECIENTOS CINCUENTA MIL PESOS M/C</example>
        [JsonPropertyName("cantidad de dinero en letras")]
        public string? LeaseAmountInWords { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>ALCOBA</example>
        [JsonPropertyName("por concepto de arrendamiento de")]
        public string? LeaseDescription { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>carrera 73a #68a 17</example>
        [JsonPropertyName("situado en")]
        public string? LeaseAddress { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <example>recibo de Ana Maria</example>
        [JsonPropertyName("nombre del archivo")]
        public string? FileName { get; set; }
    }
}
