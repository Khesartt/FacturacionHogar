using FacturacionHogar.Application.DataTransferObjects;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using SelectPdf;
using System.Security.Cryptography;

namespace FacturacionHogar.Application.Services.Extensions
{
    public static class LeaseReceiptExtension
    {
        private const string pathReciboArriendo = @"C:\Recibos";
        private const string dayFormat = "dd";
        private const string monthFormat = "MM";
        private const string yearFormat = "yyyy";
        private const string dateFormat = "dd-MM-yyyy";
        private const string numberFormat = "C";
        private const string moneySymbol = "$";
        private const string pdfExtension = ".pdf";
        private const string fileNameSample = "Sample";

        public static Dictionary<string, string> GetReplacementsWords(this LeaseReceipt pdfData)
        {
            return new Dictionary<string, string>
            {
               {"@valorReciboVar", pdfData.LeaseAmount.ToString(numberFormat).Replace(moneySymbol, string.Empty)},
               {"@NumeroReciboVar", pdfData.ReceiptNumber!},
               {"@FechaReciboVar", pdfData.ReceiptDate.ToString(dateFormat)},
               {"@arrendatarioVar", pdfData.ClientName!},
               {"@ValorTextoReciboVar", pdfData.LeaseAmountInWords!},
               {"@sitioReciboVar", pdfData.LeaseDescription!},
               {"@DireccionReciboVar", pdfData.LeaseAddress!},
               {"@diaDReciboVar", pdfData.StartDate.ToString(dayFormat)},
               {"@mesDReciboVar", pdfData.StartDate.ToString(monthFormat)},
               {"@anioDReciboVar", pdfData.StartDate.ToString(yearFormat)},
               {"@diaAReciboVar", pdfData.EndDate.ToString(dayFormat)},
               {"@mesAReciboVar", pdfData.EndDate.ToString(monthFormat)},
               {"@anioAReciboVar", pdfData.EndDate.ToString(yearFormat)}
            };
        }

        public static async Task<string> ConvertStringToPdfBase64Async(this HtmlToPdf options, string content)
        {
            PdfDocument doc = options.ConvertHtmlString(content);

            using var memoryStream = new MemoryStream();
            doc.Save(memoryStream);
            doc.Close();

            memoryStream.Position = 0;

            using var base64Transform = new ToBase64Transform();
            using var cryptoStream = new CryptoStream(memoryStream, base64Transform, CryptoStreamMode.Read);
            using var resultStream = new MemoryStream();

            await cryptoStream.CopyToAsync(resultStream).ConfigureAwait(false);

            string base64String = Encoding.ASCII.GetString(resultStream.ToArray());

            return base64String;
        }
    }
}
