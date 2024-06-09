using FacturacionHogar.Application.DataTransferObjects;
using FacturacionHogar.models;

namespace FacturacionHogar.Application.Interfaces
{
    public interface IPdfService
    {
        Response<string> GetHtmlExample();

         Response<string> GeneratePdfArriendo(LeaseReceiptPdf pdfData);
    }
}
