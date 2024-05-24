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
    public class UserBuilder : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder) {
            builder.ToTable("User");
            builder.HasKey(e => e.Id);
            builder.Property(e => e.FirstName).IsRequired().HasMaxLength(150);
            builder.Property(e => e.LastName).IsRequired().HasMaxLength(45);
            builder.Property(e => e.UserName).IsRequired().HasMaxLength(45);
            builder.Property(e => e.Password).IsRequired().HasMaxLength(150);
            builder.Property(e => e.CreatedAt).IsRequired();
            builder.Property(e => e.UpdatedAt).IsRequired(false);

            builder.HasMany(u => u.Devices)
                .WithOne(d => d.User)
                .HasForeignKey(d => d.UserId);

            builder.HasMany(u => u.Measurements)
                .WithOne(m => m.User)
                .HasForeignKey(m => m.DeviceId);
        }
    }
}
