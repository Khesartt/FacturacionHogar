using AutoMapper;
using domain = FacturacionHogar.models.domain;
using dto = FacturacionHogar.Application.DataTransferObjects;

namespace FacturacionHogar.Application.Mappings
{
    public class DefaultMappingProfile : Profile
    {
        public DefaultMappingProfile()
        {
            this.ClientMapping();
            this.LeaseReceiptMapping();
        }

        public void ClientMapping()
        {
            this.CreateMap<domain.Client, dto.Client>()
                .ForMember(target => target.Id, options => options.MapFrom(src => src.Id))
                .ForMember(target => target.Names, options => options.MapFrom(src => src.FullName));

            this.CreateMap<dto.InfoClient, domain.Client>()
                .ForMember(target => target.Identification, options => options.MapFrom(src => src.Identification))
                .ForMember(target => target.FullName, options => options.MapFrom(src => src.FullName))
                .ForMember(target => target.Phone, options => options.MapFrom(src => src.Phone))
                .ForMember(target => target.UpdateDate, options => options.MapFrom(src => DateTime.Now));

        }

        public void LeaseReceiptMapping() {

            CreateMap<domain.LeaseReceipt, dto.LeaseReceipt>()
                       .ForMember(dest => dest.ReceiptId, opt => opt.MapFrom(src => src.Id))
                       .ForMember(dest => dest.IdClient, opt => opt.MapFrom(src => src.IdClient))
                       .ForMember(dest => dest.ClientName, opt => opt.Ignore())
                       .ForMember(dest => dest.ShouldSave, opt => opt.Ignore())
                       .ForMember(dest => dest.LeaseAmount, opt => opt.MapFrom(src => src.LeaseAmount))
                       .ForMember(dest => dest.ReceiptNumber, opt => opt.MapFrom(src => src.ReceiptNumber))
                       .ForMember(dest => dest.LeaseAmountInWords, opt => opt.MapFrom(src => src.LeaseAmountInWords))
                       .ForMember(dest => dest.LeaseDescription, opt => opt.MapFrom(src => src.LeaseDescription))
                       .ForMember(dest => dest.LeaseAddress, opt => opt.MapFrom(src => src.LeaseAddress))
                       .ForMember(dest => dest.ReceiptDate, opt => opt.MapFrom(src => src.ReceiptDate))
                       .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                       .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                       .ForMember(dest => dest.LeaseReceiptType, opt => opt.MapFrom(src => src.LeaseReceiptType));

            CreateMap<dto.LeaseReceipt, domain.LeaseReceipt>()
                       .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.ReceiptId))
                       .ForMember(dest => dest.IdClient, opt => opt.MapFrom(src => src.IdClient))
                       .ForMember(dest => dest.LeaseAmount, opt => opt.MapFrom(src => src.LeaseAmount))
                       .ForMember(dest => dest.ReceiptNumber, opt => opt.MapFrom(src => src.ReceiptNumber))
                       .ForMember(dest => dest.LeaseAmountInWords, opt => opt.MapFrom(src => src.LeaseAmountInWords))
                       .ForMember(dest => dest.LeaseDescription, opt => opt.MapFrom(src => src.LeaseDescription))
                       .ForMember(dest => dest.LeaseAddress, opt => opt.MapFrom(src => src.LeaseAddress))
                       .ForMember(dest => dest.ReceiptDate, opt => opt.MapFrom(src => src.ReceiptDate))
                       .ForMember(dest => dest.StartDate, opt => opt.MapFrom(src => src.StartDate))
                       .ForMember(dest => dest.EndDate, opt => opt.MapFrom(src => src.EndDate))
                       .ForMember(dest => dest.LastUpdated, opt => opt.MapFrom(src => DateTime.UtcNow))
                       .ForMember(dest => dest.LeaseReceiptType, opt => opt.MapFrom(src => src.LeaseReceiptType));
        }
    }
}
