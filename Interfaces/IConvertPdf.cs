using FacturacionHogar.models;

namespace FacturacionHogar.Interfaces
{
    public interface IConvertPdf
    {
        Task<Response<string>> GetHtmlExample();
    }
}
