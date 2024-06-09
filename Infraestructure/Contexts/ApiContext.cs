using FacturacionHogar.Infraestructure.entityFrameworkMappings;
using FacturacionHogar.models.domain;
using Microsoft.EntityFrameworkCore;

namespace FacturacionHogar.Infraestructure.Context
{
    public class ApiContext : DbContext
    {
        private readonly IConfiguration? _configuration;

        public ApiContext()
        {
        }

        public ApiContext(DbContextOptions<ApiContext> options, IConfiguration configuration)
            : base(options)
        {
            _configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();
            var connectionString = configuration.GetConnectionString("connection");
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new ClientMapping());
            builder.ApplyConfiguration(new LeaseReceiptMapping());
            builder.ApplyConfiguration(new SampleOfServiceMapping());
            builder.ApplyConfiguration(new SamplesOfHistoryMapping());

            builder.Entity<Service>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.ServiceType).HasColumnType("varchar(500)");
                e.Property(x => x.Value).HasColumnType("decimal");
                e.Property(x => x.LastUpdate).HasColumnType("datetime");
            });
        }
    }
}
