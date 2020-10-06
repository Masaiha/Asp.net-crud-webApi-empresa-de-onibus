using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Entities;

namespace Ubus.Data.Mappings
{
    public class ProductMapping : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Name)
                .IsRequired()
                .HasColumnType("Nvarchar(200)");

            builder.Property(p => p.brand)
                .IsRequired()
                .HasColumnType("Nvarchar(200)");

            builder.Property(p => p.Price)
                .IsRequired()
                .HasColumnType("Decimal");



            builder.ToTable("Products");
        }
    }
}
