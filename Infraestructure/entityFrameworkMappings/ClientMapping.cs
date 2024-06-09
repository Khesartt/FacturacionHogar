using FacturacionHogar.models.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacturacionHogar.Infraestructure.entityFrameworkMappings
{
    public class ClientMapping : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.ToTable("Clientes");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.FullName).HasColumnType("varchar(500)");
            builder.Property(x => x.Identification).HasColumnType("varchar(500)");
            builder.Property(x => x.Phone).HasColumnType("varchar(500)");
            builder.Property(x => x.Email).HasColumnType("varchar(500)");
            builder.Property(x => x.UpdateDate).HasColumnType("datetime");
        }
    }
}
