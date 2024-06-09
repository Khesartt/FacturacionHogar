using FacturacionHogar.models.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacturacionHogar.Infraestructure.entityFrameworkMappings
{
    public class SamplesOfHistoryMapping: IEntityTypeConfiguration<SamplesHistory>
    {
        public void Configure(EntityTypeBuilder<SamplesHistory> builder) {

            builder.ToTable("historiaDeLecturas");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.ServiceType).HasColumnType("varchar(500)");
            builder.Property(x => x.SampleDate).HasColumnType("datetime");
            builder.Property(x => x.Sample).HasColumnType("decimal");
        }
    }
}
