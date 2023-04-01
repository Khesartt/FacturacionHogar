using FacturacionHogar.Dominio.modelos;
using Microsoft.EntityFrameworkCore;
using System;

namespace FacturacionHogar.Context
{
    public class ApiContext : DbContext
    {

        public DbSet<Cliente> cliente { get; set; }
        public DbSet<Parametric> parametric { get; set; }
        public DbSet<ReciboArrendamiento> reciboArrendamiento { get; set; }
        public DbSet<Servicio> servicio { get; set; }

        private IConfiguration _configuration;
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
            builder.Entity<Cliente>(e =>
           {
               e.HasKey(x => x.id);

               e.Property(x => x.nombres).HasColumnType("varchar(500)");
               e.Property(x => x.cedula).HasColumnType("varchar(500)");
               e.Property(x => x.celular).HasColumnType("varchar(500)");
               e.Property(x => x.correo).HasColumnType("varchar(500)");
               e.Property(x => x.fechaActualizacion).HasColumnType("datetime");
           });

            builder.Entity<Parametric>(e =>
            {
                e.HasKey(x => x.id);

                e.Property(x => x.tipo).HasColumnType("varchar(500)");
                e.Property(x => x.valor).HasColumnType("varchar(500)");
                e.Property(x => x.fechaActualizacion).HasColumnType("datetime");
            });

            builder.Entity<ReciboArrendamiento>(e =>
            {
                e.HasKey(x => x.id);

                e.HasOne<Cliente>().WithMany().HasForeignKey(x => x.idCliente).HasConstraintName("FK_reciboCliente");

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

                e.HasOne<Cliente>().WithMany().HasForeignKey(x => x.idCliente).HasConstraintName("FK_servicioCliente");
                e.HasOne<Parametric>().WithMany().HasForeignKey(x => x.idParametric).HasConstraintName("FK_servicioParametric");
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
