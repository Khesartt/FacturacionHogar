using FacturacionHogar.models;

namespace FacturacionHogar.Application.Interfaces
{
    public interface IPdfService
    {
        Task<Response<string>> GetHtmlExample();

        Task<Response<string>> GeneratePdfArriendo(object pdfData);
    }
}
