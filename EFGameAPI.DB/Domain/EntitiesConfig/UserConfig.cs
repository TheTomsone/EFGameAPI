using EFGameAPI.DB.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DB.Domain.EntitiesConfig
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(nameof(User));

            builder.Property(nameof(User.Id)).ValueGeneratedNever();

            builder.HasIndex(nameof(User.Username)).IsUnique();
            builder.Property(nameof(User.Username))
                    .HasColumnType("VARCHAR(100)")
                    .IsRequired();

            builder.HasIndex(nameof(User.Email)).IsUnique();
            builder.Property(nameof(User.Email))
                    .HasColumnType("VARCHAR(100)")
                    .IsRequired();

            builder.Property(nameof(User.PasswordHash))
                    .HasColumnType("VARBINARY(64)")
                    .IsRequired();

            builder.Property(nameof(User.Salt))
                    .HasColumnType("VARCHAR(100)")
                    .IsRequired();

            builder.Property(nameof(User.RoleId))
                    .HasColumnType("INT")
                    .HasDefaultValue(1)
                    .IsRequired();
        }
    }
}
