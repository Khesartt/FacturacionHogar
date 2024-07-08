using AutoMapper;
using FacturacionHogar.Application.DataTransferObjects;
using FacturacionHogar.Application.Interfaces;
using FacturacionHogar.Infraestructure.Interfaces;
using SelectPdf;
namespace FacturacionHogar.Application.Services
{
    public class LeaseReceiptService : ILeaseReceiptService
    {
        private const int margin = -300;


        private readonly string[] templateRoute = { "resources", "assets", "LeaseReceiptTemplate.html" };
        private readonly string[] boostrapRoute = { "resources", "htmlHelper" };
        private readonly string html;
        private readonly HtmlToPdf htmlToPdfOptions;
        private readonly ILeaseReceiptRepository leaseReceiptRepository;
        private readonly IClientRepository clientRepository;
        private readonly IMapper mapper;

        public LeaseReceiptService(IWebHostEnvironment _env,
                                   ILeaseReceiptRepository leaseReceiptRepository,
                                   IClientRepository clientRepository,
                                   IMapper mapper)
        {
            this.leaseReceiptRepository = leaseReceiptRepository;
            this.clientRepository = clientRepository;
            this.mapper = mapper;

            string templatePath = Path.Combine(_env.ContentRootPath, templateRoute[0], templateRoute[1], templateRoute[2]);
            string boostrapPath = Path.Combine(_env.ContentRootPath, boostrapRoute[0], boostrapRoute[1]);

            html = File.ReadAllText(templatePath);
            html = html.Replace("@ruta", boostrapPath);

            htmlToPdfOptions = new()
            {
                Options =
                {
                   PdfPageSize = PdfPageSize.Note,
                   PdfPageOrientation = PdfPageOrientation.Landscape,
                   MarginTop = 0,
                   MarginLeft = 0,
                   MarginRight = margin,
                   MarginBottom = margin,
                   MinPageLoadTime = 3
                }
            };

        }

        public async Task<LeaseReceipt> GetLastLeaseReceiptByClientAsync(long clientId)
        {
            var leaseReceiptByDomain = await this.leaseReceiptRepository.GetByClientIdAsync(lease => lease.IdClient == clientId)
                                        ?? throw new KeyNotFoundException($"LeaseReceipt for client ID {clientId} not found.");

            var client = await this.clientRepository.GetByIdAsync(clientId)
                         ?? throw new KeyNotFoundException($"Client with ID {clientId} not found.");

            var leaseReceipt = this.mapper.Map<LeaseReceipt>(leaseReceiptByDomain);
            leaseReceipt.FullNameClient = client.FullName;

            return leaseReceipt;
        }

        public async Task<string> GenerateLeaseReceiptBase64ByClientAsync()
        {





            return null;
        }
    }
}
