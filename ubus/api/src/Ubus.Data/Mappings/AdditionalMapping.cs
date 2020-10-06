using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Entities;

namespace Ubus.Data.Mappings
{
    public class AdditionalMapping : IEntityTypeConfiguration<Additional>
    {
        public void Configure(EntityTypeBuilder<Additional> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.isHasMinibar)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(b => b.isHasAirConditioning)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(b => b.isHasBathroom)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(b => b.isHaswifi)
                .IsRequired()
                .HasColumnType("bit");

            builder.ToTable("Additionals");
        }
    }
}
