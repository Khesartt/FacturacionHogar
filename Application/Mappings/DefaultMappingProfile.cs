using AutoMapper;
using domain = FacturacionHogar.models.domain;
using System.Drawing;
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
        }
    }
}
