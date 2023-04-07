using FacturacionHogar.models;
using FacturacionHogar.models.DTO_s;

namespace FacturacionHogar.Interfaces
{
    public interface IPdfService
    {
        Task<Response<string>> GetHtmlExample();

        Task<Response<string>> GeneratePdfArriendo(PdfArriendoDto pdfData);
    }
}
