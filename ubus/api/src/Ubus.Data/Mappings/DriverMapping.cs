using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using Ubus.Business.Entities;

namespace Ubus.Data.Mappings
{
    public class DriverMapping : IEntityTypeConfiguration<Driver>
    {
        public void Configure(EntityTypeBuilder<Driver> builder)
        {
            builder.HasKey(d => d.Id);

            builder.Property(d => d.Name)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(d => d.Cpf)
                .IsRequired()
                .HasMaxLength(11)
                .HasColumnType("varchar(11)");

            builder.Property(d => d.Age)
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(d => d.IsActive)
                .IsRequired()
                .HasColumnType("bit");

            builder.Property(d => d.Age)
                .IsRequired()
                .HasColumnType("Integer");

            builder.Property(d => d.Cpf)
                .IsRequired()
                .HasColumnType("varchar(11)");

            builder.ToTable("Drives");
        }
    }
}
