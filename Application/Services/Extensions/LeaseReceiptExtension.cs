using FacturacionHogar.Application.DataTransferObjects;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;
using SelectPdf;
using System.Drawing.Printing;

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

        public static Dictionary<string, string> GetReplacementsWords(LeaseReceiptPdf pdfData)
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
        public static string NormalizeFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return fileNameSample + new DateTime().ToString(dateFormat);
            }

            string normalized = Regex.Replace(fileName, @"[^\w\s]", "");

            string filePathName = new string(normalized.Normalize(NormalizationForm.FormD)
                                                       .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                                                       .ToArray())
                                                       .Normalize(NormalizationForm.FormC);

            return Path.Combine(pathReciboArriendo, filePathName + pdfExtension);
        }

        public static string ConvertStringToPdfBase64(HtmlToPdf options, string content)
        {
            PdfDocument doc = options.ConvertHtmlString(content);

            using var memoryStream = new MemoryStream();

            doc.Save(memoryStream);
            doc.Close();

            return Convert.ToBase64String(memoryStream.ToArray());
        }
    }
}
