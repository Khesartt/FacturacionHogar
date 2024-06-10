using FacturacionHogar.Application.DataTransferObjects;
using FacturacionHogar.Application.Interfaces;
using FacturacionHogar.models;
using SelectPdf;
using System.Globalization;
using System.Text.RegularExpressions;
using System.Text;

namespace FacturacionHogar.Application.Services
{
    public class PdfService : IPdfService
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

        private readonly IWebHostEnvironment env;
        private readonly string[] templateRoute = { "resources", "assets", "plantilla.html" };
        private readonly string[] boostrapRoute = { "resources", "htmlHelper" };
        private readonly string html;

        private static readonly int margin = -300;

        public PdfService(IWebHostEnvironment _env)
        {
            env = _env;

            string templatePath = Path.Combine(_env.ContentRootPath, templateRoute[0], templateRoute[1], templateRoute[2]);
            string boostrapPath = Path.Combine(_env.ContentRootPath, boostrapRoute[0], boostrapRoute[1]);


            html = File.ReadAllText(templatePath);
            html = html.Replace("@ruta", boostrapPath);
        }

        public Response<string> GetHtmlExample()
        {
            try
            {
                GeneratePdfReciboArriendo(html, fileNameSample);
                return new Response<string>(html);
            }
            catch (Exception ex)
            {
                return new Response<string>(ex);
            }
        }
        public Response<string> GeneratePdfArriendo(LeaseReceiptPdf pdfData)
        {
            string htmlToEdit = html;

            foreach (var replacement in GetReplacementsWords(pdfData))
            {
                htmlToEdit = htmlToEdit.Replace(replacement.Key, replacement.Value);
            }

            try
            {
                string fileNamePath = NormalizeFileName(pdfData.FileName!);

                GeneratePdfReciboArriendo(htmlToEdit, fileNamePath);
                byte[] fileBytes = File.ReadAllBytes(fileNamePath);
                string base64String = Convert.ToBase64String(fileBytes);

                return new Response<string>(base64String);
            }
            catch (Exception ex)
            {
                return new Response<string>(ex);
            }
        }

        private static Dictionary<string, string> GetReplacementsWords(LeaseReceiptPdf pdfData)
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

        private static void GeneratePdfReciboArriendo(string html, string fileName)
        {
            HtmlToPdf convert = new()
            {
                Options = {
                PdfPageSize = PdfPageSize.Note,
                PdfPageOrientation = PdfPageOrientation.Landscape,
                MarginTop = 0,
                MarginLeft = 0,
                MarginRight = margin,
                MarginBottom = margin,
                MinPageLoadTime = 3
                }
            };

            PdfDocument doc = convert.ConvertHtmlString(html);
            {
                doc.Save(fileName);
            }
        }

        private static string NormalizeFileName(string fileName)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                return fileNameSample;
            }

            string normalized = Regex.Replace(fileName, @"[^\w\s]", "");

            string filePathName = new string(normalized
                                  .Normalize(NormalizationForm.FormD)
                                  .Where(c => CharUnicodeInfo.GetUnicodeCategory(c) != UnicodeCategory.NonSpacingMark)
                                  .ToArray())
                                  .Normalize(NormalizationForm.FormC);

            return Path.Combine(pathReciboArriendo, filePathName + pdfExtension);
        }
    }
}
/*
cosas que pueden ser utiles para el documento
 
convert.Options.CssMediaType = SelectPdf.HtmlToPdfCssMediaType.Print;
 
convert.Options.EmbedFonts = true;
 
convert.Options.ExternalLinksEnabled = true;
 
convert.Options.InternalLinksEnabled = true;
 
convert.Options.JavaScriptEnabled = true;
 */