using EldenLabs.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EldenLabs.Infrastructure.Builders
{
    public class MeasurementBuilder : IEntityTypeConfiguration<Measurement>
    {
        public void Configure(EntityTypeBuilder<Measurement> builder)
        {
            builder.ToTable("Measurement");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.EventProcessed).IsRequired().HasMaxLength(150);
            builder.Property(e => e.DeviceId).IsRequired().HasMaxLength(45);
            builder.Property(e => e.CreatedAt).IsRequired();
            builder.HasOne(m => m.Device)
                .WithMany(d => d.Measurements)
                .HasForeignKey(m => m.DeviceId);

            // Configuring the relationship with User
            builder.HasOne(m => m.User)
                .WithMany(u => u.Measurements)
                .HasForeignKey(m => m.DeviceId);
        }
  
    }
}
