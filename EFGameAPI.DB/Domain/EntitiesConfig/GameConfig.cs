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
    public class GameConfig : IEntityTypeConfiguration<Game>
    {
        public void Configure(EntityTypeBuilder<Game> builder)
        {
            builder.ToTable(nameof(Game));

            builder.Property(nameof(Game.Id)).ValueGeneratedNever();

            builder.HasIndex(nameof(Game.Title)).IsUnique();
            builder.Property(nameof(Game.Title))
                    .HasColumnType("VARCHAR(100)")
                    .IsRequired();

            builder.Property(nameof(Game.Resume))
                    .HasColumnType("VARCHAR(MAX)")
                    .IsRequired();

            builder.HasData(
                new Game
                {
                    Id = 1,
                    Title = "Counter-Strike 2",
                    Resume = "The largest technical leap forward in Counter-Strike''s history, ensuring new features and updates for years to come.",
                },
                new Game
                {
                    Id = 2,
                    Title = "Star Citizen",
                    Resume = "In-development multiplayer, space trading and combat simulation game. The game is being developed and published by Cloud Imperium Games",
                },
                new Game
                {
                    Id = 3,
                    Title = "Baldur's Gate 3",
                    Resume = "Role-playing video game developed and published by Larian Studios. It is the third main installment in the Baldur''s Gate series, based on the tabletop role-playing system of Dungeons & Dragons.",
                }
                );
        }
    }
}
