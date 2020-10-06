using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ubus.Business.Entities;

namespace Ubus.Data.Mappings
{
    public class MiniBarMapping : IEntityTypeConfiguration<MiniBar>
    {
        public void Configure(EntityTypeBuilder<MiniBar> builder)
        {
            builder.HasKey(m => m.Id);

            builder.HasMany(m => m.Bus)
                .WithOne(b => b.MiniBar)
                .HasForeignKey(b => b.MiniBarId);

            builder.ToTable("MiniBars");
                
        }
    }
}
