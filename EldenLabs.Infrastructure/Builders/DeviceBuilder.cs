using EldenLabs.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Infrastructure.Builders
{
    public class DeviceBuilder : IEntityTypeConfiguration<Device>
    {
        public void Configure(EntityTypeBuilder<Device> builder)
        {
            builder.ToTable("Device");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.NameDevice).IsRequired().HasMaxLength(150);
            builder.Property(e => e.UserId).IsRequired().HasMaxLength(45);
            builder.Property(e => e.CreatedAt).IsRequired();

            builder.HasOne(d => d.User)
                .WithMany(u => u.Devices)
                .HasForeignKey(d => d.UserId);
        }

    }
}