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
    }
}
