using FacturacionHogar.Application.Interfaces;
using FacturacionHogar.Application.Services;
using FacturacionHogar.Infraestructure.Interfaces;
using FacturacionHogar.Infraestructure.repositories;

namespace FacturacionHogar.Infraestructure.Configs
{
    public static class RegisterExtension
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {
            services.AddScoped<IPdfService, PdfService>();

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
