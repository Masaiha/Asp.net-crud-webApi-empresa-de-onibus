using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Entities;

namespace Ubus.Data.Mappings
{
    public class TripDriverMapping : IEntityTypeConfiguration<TripDriver>
    {
        public void Configure(EntityTypeBuilder<TripDriver> builder)
        {
            builder.HasKey(t => t.Id);

            

            builder.ToTable("TripDrivers");
        }
    }
}
