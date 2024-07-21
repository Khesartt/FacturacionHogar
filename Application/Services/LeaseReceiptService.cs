using AutoMapper;
using FacturacionHogar.Application.DataTransferObjects;
using FacturacionHogar.Application.Interfaces;
using FacturacionHogar.Infraestructure.Interfaces;
using SelectPdf;
using FacturacionHogar.Application.Services.Extensions;
using domain = FacturacionHogar.models.domain;

namespace FacturacionHogar.Application.Services
{
    public class LeaseReceiptService : ILeaseReceiptService
    {
        private const int margin = -300;
        private const string defaultExtensionLeaseReceipt = ".pdf";
        private const string defaultTypeLeaseReceipt = "application/pdf";
        private const string dateFormat = "dd-MM-yyyy";

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
            leaseReceipt.ClientName = client.FullName;

            return leaseReceipt;
        }

        public async Task<LeaseReceiptFile> GenerateLeaseReceiptBase64ByClientAsync(LeaseReceipt leaseReceipt)
        {
            string leaseReceiptHtml = this.html;

            foreach (var replacement in leaseReceipt.GetReplacementsWords())
            {
                leaseReceiptHtml = leaseReceiptHtml.Replace(replacement.Key, replacement.Value);
            }

            return new LeaseReceiptFile
            {
                FileName = GetFileNameByLeaseReceipt(leaseReceipt),
                FileContent = await htmlToPdfOptions.ConvertStringToPdfBase64Async(leaseReceiptHtml),
                FileExtension = defaultExtensionLeaseReceipt,
                FileType = defaultTypeLeaseReceipt
            };
        }

        public async Task SaveLeaseReceiptByClientAsync(LeaseReceipt leaseReceiptDto)
        {
            try
            {
                var existingLeaseReceipt = await this.leaseReceiptRepository.GetByIdAsync(leaseReceiptDto.ReceiptId);

                if (existingLeaseReceipt != null)
                {
                    this.mapper.Map(leaseReceiptDto, existingLeaseReceipt);

                    await this.leaseReceiptRepository.UpdateAsync(existingLeaseReceipt);
                }
                else
                {
                    domain.LeaseReceipt leaseReceipt = this.mapper.Map<domain.LeaseReceipt>(leaseReceiptDto);
                    
                    await this.leaseReceiptRepository.AddAsync(leaseReceipt);
                }

                var client = await this.clientRepository.GetByIdAsync(leaseReceiptDto.IdClient);

                client.FullName =  leaseReceiptDto.ClientName;

                await this.clientRepository.UpdateAsync(client);

            }
            catch (Exception ex)
            {
                throw new ApplicationException("An error has appear near trying to save the leaseReceipt", ex);
            }
        }

        private static string GetFileNameByLeaseReceipt(LeaseReceipt leaseReceipt)
        {
            return $"{leaseReceipt.ReceiptNumber}-{leaseReceipt.ClientName!.NormalizeFileName()}-({leaseReceipt.ReceiptDate.ToString(dateFormat)})";
        }
    }
}
