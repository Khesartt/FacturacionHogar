using FacturacionHogar.Application.DataTransferObjects;
using FacturacionHogar.Application.Interfaces;
using FacturacionHogar.models;
using Microsoft.AspNetCore.Mvc;
namespace FacturacionHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController
    {
        private readonly IPdfService _pdfService;

        public PdfController(IPdfService pdfService)
        {
            _pdfService = pdfService;
        }

        [HttpGet("GetHtml")]
        public Response<string> GetHtmlExample()
        {
            return _pdfService.GetHtmlExample();
        }

        [HttpPost("GetReciboArriendo")]
        public Response<string> GetReciboArriendo([FromBody] LeaseReceiptPdf pdfData)
        {
            return _pdfService.GeneratePdfArriendo(pdfData);
        }
    }
}
