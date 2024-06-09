﻿using FacturacionHogar.Application.Interfaces;
using FacturacionHogar.models;
using Microsoft.AspNetCore.Mvc;
namespace FacturacionHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PdfController
    {
        private IPdfService pdfService;

        public PdfController(IPdfService _pdfService)
        {
            pdfService = _pdfService;
        }

        [HttpGet("GetHtml")]
        public Response<string> GetHtmlExample()
        {
            return pdfService.GetHtmlExample().Result;
        }
        [HttpPost("GetReciboArriendo")]
        public Response<string> GetReciboArriendo([FromBody] object pdfData)
        {
            return pdfService.GeneratePdfArriendo(pdfData).Result;
        }
    }
}
