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
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            builder.ToTable(nameof(Genre));

            builder.Property(nameof(Genre.Id)).ValueGeneratedNever();

            builder.HasIndex(nameof(Genre.Label)).IsUnique();
            builder.Property(nameof(Genre.Label))
                    .HasColumnType("VARCHAR(100)")
                    .IsRequired();

            builder.HasData(
                new Genre
                {
                    Id = 1,
                    Label = "Action",
                },
                new Genre
                {
                    Id = 2,
                    Label = "Adventure",
                },
                new Genre
                {
                    Id = 3,
                    Label = "Coop",
                },
                new Genre
                {
                    Id = 4,
                    Label = "Early Access",
                },
                new Genre
                {
                    Id = 5,
                    Label = "FPS",
                },
                new Genre
                {
                    Id = 6,
                    Label = "Free to Play",
                },
                new Genre
                {
                    Id = 7,
                    Label = "MMO",
                },
                new Genre
                {
                    Id = 8,
                    Label = "Management",
                },
                new Genre
                {
                    Id = 9,
                    Label = "Multi",
                },
                new Genre
                {
                    Id = 10,
                    Label = "RPG",
                },
                new Genre
                {
                    Id = 11,
                    Label = "Racing",
                },
                new Genre
                {
                    Id = 12,
                    Label = "Simulation",
                },
                new Genre
                {
                    Id = 13,
                    Label = "Solo",
                }
                );
        }
    }
}
