using FacturacionHogar.Application.DataTransferObjects;
using FacturacionHogar.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace FacturacionHogar.Controllers
{
    [Route("api/[controller]")]
    public class LeaseReceiptController : ControllerBase
    {
        private readonly ILeaseReceiptService leaseReceiptService;

        public LeaseReceiptController(ILeaseReceiptService leaseReceiptService)
        {
            this.leaseReceiptService = leaseReceiptService;
        }

        [HttpGet("GetLastReceipt/{clientId}")]
        public async Task<IActionResult> GetLastLeaseReceiptByClientAsync(long clientId)
        {
            try
            {
                var leaseReceipt = await this.leaseReceiptService.GetLastLeaseReceiptByClientAsync(clientId);

                return Ok(leaseReceipt);
            }
            catch (KeyNotFoundException ex)
            {
                return this.NotFound(ex.Message);
            }
        }
    }
}
