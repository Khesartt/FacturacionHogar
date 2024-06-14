using AutoMapper;
using FacturacionHogar.Application.Interfaces;
using FacturacionHogar.Application.Mappings;
using FacturacionHogar.Application.Services;
using FacturacionHogar.Infraestructure.Interfaces;
using FacturacionHogar.Infraestructure.repositories;

namespace FacturacionHogar.Infraestructure.Configs
{
    public static class RegisterExtension
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection services)
        {
            MapperConfiguration mp = new (cfg =>
            {
                cfg.AddProfile<DefaultMappingProfile>();
            });

            services.AddSingleton<IMapper>(sp => new Mapper(mp));
            services.AddTransient<IPdfService, PdfService>();
            services.AddTransient<IClientService, ClientService>();

            return services;
        }

        public static IServiceCollection RegisterRepositories(this IServiceCollection services)
        {
            services.AddTransient<IClientRepository, ClientRepository>();
            services.AddTransient<ILeaseReceiptRepository, LeaseReceiptRepository>();
            services.AddTransient<ISampleOfServiceRepository, SampleOfServiceRepository>();
            services.AddTransient<ISamplesHistoryRepository, SamplesHistoryRepository>();
            services.AddTransient<IServiceRepository, ServiceRepository>();

            return services;
        }
    }
}
