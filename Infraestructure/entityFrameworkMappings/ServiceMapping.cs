using FacturacionHogar.models.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacturacionHogar.Infraestructure.entityFrameworkMappings
{
    public class ServiceMapping : IEntityTypeConfiguration<Service>
    {
        public void Configure(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Servicios");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ServiceType).HasColumnType("varchar(500)");
            builder.Property(x => x.Value).HasColumnType("decimal");
            builder.Property(x => x.LastUpdate).HasColumnType("datetime");
        }
    }
}
