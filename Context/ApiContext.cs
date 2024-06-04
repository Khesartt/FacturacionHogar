using FacturacionHogar.models.domain;
using Microsoft.EntityFrameworkCore;

namespace FacturacionHogar.Context
{
    public class ApiContext : DbContext
    {

        public DbSet<Client>? Clients { get; set; }

        public DbSet<Service>? Services { get; set; }

        public DbSet<LeaseReceipt>? LeaseReceipts { get; set; }

        public DbSet<SampleOfService>? SampleOfServices { get; set; }

        public DbSet<SamplesHistory>? SamplesHistories { get; set; }


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
            builder.Entity<Client>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.FullName).HasColumnType("varchar(500)");
                e.Property(x => x.Identification).HasColumnType("varchar(500)");
                e.Property(x => x.Phone).HasColumnType("varchar(500)");
                e.Property(x => x.Email).HasColumnType("varchar(500)");
                e.Property(x => x.UpdateDate).HasColumnType("datetime");
            });

            builder.Entity<Service>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.ServiceType).HasColumnType("varchar(500)");
                e.Property(x => x.Value).HasColumnType("decimal");
                e.Property(x => x.LastUpdate).HasColumnType("datetime");
            });

            builder.Entity<LeaseReceipt>(e =>
            {
                e.HasKey(x => x.Id);

                e.HasOne<Client>().WithMany().HasForeignKey(x => x.IdClient).HasConstraintName("FK_reciboCliente");
                e.Property(x => x.IdClient).HasColumnType("bigint");

                e.Property(x => x.LeaseAmount).HasColumnType("varchar(500)");
                e.Property(x => x.ReceiptNumber).HasColumnType("varchar(500)");
                e.Property(x => x.ReceiptDate).HasColumnType("datetime");
                e.Property(x => x.LeaseAmountInWords).HasColumnType("varchar(500)");
                e.Property(x => x.LeaseDescription).HasColumnType("varchar(500)");
                e.Property(x => x.LeaseAddress).HasColumnType("varchar(500)");
                e.Property(x => x.StartDate).HasColumnType("datetime");
                e.Property(x => x.EndDate).HasColumnType("datetime");
                e.Property(x => x.LastUpdated).HasColumnType("datetime");
            });

            builder.Entity<SampleOfService>(e =>
            {
                e.HasKey(x => x.Id);

                e.HasOne<Client>().WithMany().HasForeignKey(x => x.IdClient).HasConstraintName("FK_servicioCliente");
                e.HasOne<Service>().WithMany().HasForeignKey(x => x.IdService).HasConstraintName("FK_servicioParametric");
                e.Property(x => x.IdClient).HasColumnType("bigint");
                e.Property(x => x.IdService).HasColumnType("bigint");

                e.Property(x => x.CurrentSample).HasColumnType("decimal");
                e.Property(x => x.LastSample).HasColumnType("decimal");
                e.Property(x => x.CurrentDate).HasColumnType("datetime");
            });

            builder.Entity<SamplesHistory>(e =>
            {
                e.HasKey(x => x.Id);

                e.Property(x => x.ServiceType).HasColumnType("varchar(500)");
                e.Property(x => x.SampleDate).HasColumnType("datetime");
                e.Property(x => x.Sample).HasColumnType("decimal");
            });
        }
    }
}
