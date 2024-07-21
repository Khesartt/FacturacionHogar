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

        [HttpPost("SaveLeaseReceipt")]
        public async Task<IActionResult> SaveAndGenerateLeaseReceiptDocument([FromBody] LeaseReceipt leaseReceipt)
        {
            try
            {
                if (leaseReceipt.ShouldSave) {

                    await this.leaseReceiptService.SaveLeaseReceiptByClientAsync(leaseReceipt);
                }

                var fileData = await this.leaseReceiptService.GenerateLeaseReceiptBase64ByClientAsync(leaseReceipt); 

                return Ok(fileData);
            }
            catch (ApplicationException ex)
            {
                return this.NotFound(ex.Message);
            }
        }
    }
}
