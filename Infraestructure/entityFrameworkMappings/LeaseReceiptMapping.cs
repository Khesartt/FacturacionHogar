using FacturacionHogar.models.domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FacturacionHogar.Infraestructure.entityFrameworkMappings
{
    public class LeaseReceiptMapping : IEntityTypeConfiguration<LeaseReceipt>
    {

        public void Configure(EntityTypeBuilder<LeaseReceipt> builder)
        {
            builder.ToTable("Facturas");

            builder.HasKey(x => x.Id);

            builder.HasOne<Client>().WithMany()
                                    .HasForeignKey(x => x.IdClient)
                                    .HasConstraintName("FK_IdClientByLeaseReceipt");

            builder.Property(x => x.IdClient).HasColumnType("bigint");

            builder.Property(x => x.LeaseAmount).HasColumnType("bigint");
            builder.Property(x => x.ReceiptNumber).HasColumnType("varchar(500)");
            builder.Property(x => x.ReceiptDate).HasColumnType("datetime");
            builder.Property(x => x.LeaseAmountInWords).HasColumnType("varchar(500)");
            builder.Property(x => x.LeaseDescription).HasColumnType("varchar(500)");
            builder.Property(x => x.LeaseAddress).HasColumnType("varchar(500)");
            builder.Property(x => x.StartDate).HasColumnType("datetime");
            builder.Property(x => x.EndDate).HasColumnType("datetime");
            builder.Property(x => x.LastUpdated).HasColumnType("datetime");
            builder.Property(x => x.LeaseReceiptType).HasColumnType("varchar(500)");
        }
    }
}
