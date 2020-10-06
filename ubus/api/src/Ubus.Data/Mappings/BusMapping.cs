using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Entities;

namespace Ubus.Data.Mappings
{
    public class BusMapping : IEntityTypeConfiguration<Bus>
    {
        public void Configure(EntityTypeBuilder<Bus> builder)
        {
            builder.HasKey(b => b.Id);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasColumnType("NVarchar(200)");

            builder.HasOne(a => a.Additional)
                .WithOne(b => b.Bus);

            builder.ToTable("Bus");
        }
    }
}
