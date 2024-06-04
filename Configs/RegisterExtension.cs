using FacturacionHogar.Interfaces;
using FacturacionHogar.Services;

namespace FacturacionHogar.Configs
{
    public static class RegisterExtension
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection services)
        {

            services.AddScoped<IPdfService, PdfService>();

            return services;
        }
    }
}
