using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Entities;

namespace Ubus.Data.Mappings
{
    public class TripMapping : IEntityTypeConfiguration<Trip>
    {
        public void Configure(EntityTypeBuilder<Trip> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Name)
                .IsRequired()
                .HasColumnType("NVarchar(200)");

            builder.Property(t => t.StartDate)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.Property(t => t.EndDate)
                .IsRequired()
                .HasColumnType("DateTime");

            builder.HasOne(t => t.Driver)
                .WithOne(d => d.Trip);

            builder.HasOne(t => t.Route)
                .WithMany(r => r.Trips)
                .HasForeignKey(t => t.RouteId);

            builder.ToTable("Trips");
        }
    }
}
