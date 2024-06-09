using FacturacionHogar.models.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacturacionHogar.Infraestructure.entityFrameworkMappings
{
    public class SampleOfServiceMapping : IEntityTypeConfiguration<SampleOfService>
    {
        public void Configure(EntityTypeBuilder<SampleOfService> builder)
        {
            builder.ToTable("LecturasPorServicio");

            builder.HasKey(x => x.Id);

            builder.HasOne<Client>().WithMany()
                                    .HasForeignKey(x => x.IdClient)
                                    .HasConstraintName("FK_IdClientBySample");

            builder.HasOne<Service>().WithMany()
                                     .HasForeignKey(x => x.IdService)
                                     .HasConstraintName("FK_IdServiceBySample");

            builder.Property(x => x.IdClient).HasColumnType("bigint");
            builder.Property(x => x.IdService).HasColumnType("bigint");
            builder.Property(x => x.CurrentSample).HasColumnType("decimal");
            builder.Property(x => x.LastSample).HasColumnType("decimal");
            builder.Property(x => x.CurrentDate).HasColumnType("datetime");
        }
    }
}
