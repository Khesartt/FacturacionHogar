using FacturacionHogar.Interfaces;
using Microsoft.AspNetCore.Mvc;
namespace FacturacionHogar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrincipalController
    {
        private IConvertPdf convertPdf;

        public PrincipalController(IConvertPdf _convertPdf)
        {
            convertPdf = _convertPdf;
        }

        [HttpGet("getExample")]
        public string GetAll()
        {
            return convertPdf.getHtmlExample();
        }
        //// GET: api/Countries
        //[HttpGet("getCountries")]
        //public Respond<Country> Getcountries()
        //{
        //    return countryServices.getCountries();
        //}

        //// GET: api/Countries/5
        //[HttpGet("{id}")]
        //public Respond<Country> GetCountry(int id)
        //{
        //    return countryServices.GetCountry(id);
        //}
        //[HttpPost]
        //public Respond<Country> PostCountry(Country country)
        //{
        //    return countryServices.addCountry(country);
        //}
    }
}
