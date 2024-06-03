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
                e.Property(x => x.Value).HasColumnType("varchar(500)");
                e.Property(x => x.LastUpdate).HasColumnType("datetime");
            });

            builder.Entity<ReciboArrendamiento>(e =>
            {
                e.HasKey(x => x.id);

                e.HasOne<Client>().WithMany().HasForeignKey(x => x.idCliente).HasConstraintName("FK_reciboCliente");

                e.Property(x => x.valorArrendamiento).HasColumnType("varchar(500)");
                e.Property(x => x.numeroRecibo).HasColumnType("varchar(500)");
                e.Property(x => x.fechaRecibo).HasColumnType("datetime");
                e.Property(x => x.nombreCliente).HasColumnType("varchar(500)");
                e.Property(x => x.valorArrendamientoLetra).HasColumnType("varchar(500)");
                e.Property(x => x.descripcionArrendamiento).HasColumnType("varchar(500)");
                e.Property(x => x.direccionArrendamiento).HasColumnType("varchar(500)");
                e.Property(x => x.fechaInicial).HasColumnType("datetime");
                e.Property(x => x.fechaFinal).HasColumnType("datetime");
                e.Property(x => x.idCliente).HasColumnType("bigint");
                e.Property(x => x.fechaActualizacion).HasColumnType("datetime");
            });

            builder.Entity<Servicio>(e =>
            {
                e.HasKey(x => x.id);

                e.HasOne<Client>().WithMany().HasForeignKey(x => x.idCliente).HasConstraintName("FK_servicioCliente");
                e.HasOne<Service>().WithMany().HasForeignKey(x => x.idParametric).HasConstraintName("FK_servicioParametric");
                e.Property(x => x.medicionBackUp).HasColumnType("varchar(500)");
                e.Property(x => x.medicionAnterior).HasColumnType("varchar(500)");
                e.Property(x => x.medicionActual).HasColumnType("varchar(500)");
                e.Property(x => x.idCliente).HasColumnType("bigint");
                e.Property(x => x.idParametric).HasColumnType("bigint");
                e.Property(x => x.fechaActualizacion).HasColumnType("datetime");
            });



        }
    }
}
