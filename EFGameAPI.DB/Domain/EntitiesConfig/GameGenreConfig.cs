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
    public class GameGenreConfig : IEntityTypeConfiguration<GameGenre>
    {
        public void Configure(EntityTypeBuilder<GameGenre> builder)
        {
            builder.HasKey(nameof(GameGenre.GameId), nameof(GameGenre.GenreId));

            builder.HasOne(x => x.Game)
                    .WithMany(x => x.Genres)
                    .HasForeignKey(x => x.GameId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Genre)
                    .WithMany(x => x.Games)
                    .HasForeignKey(x => x.GenreId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasData(
                new GameGenre { GameId = 1, GenreId = 1 },
                new GameGenre { GameId = 1, GenreId = 3 },
                new GameGenre { GameId = 1, GenreId = 5 },
                new GameGenre { GameId = 1, GenreId = 6 },
                new GameGenre { GameId = 1, GenreId = 9 },
                new GameGenre { GameId = 2, GenreId = 2 },
                new GameGenre { GameId = 2, GenreId = 3 },
                new GameGenre { GameId = 2, GenreId = 10 },
                new GameGenre { GameId = 2, GenreId = 13 },
                new GameGenre { GameId = 3, GenreId = 1 },
                new GameGenre { GameId = 3, GenreId = 2 },
                new GameGenre { GameId = 3, GenreId = 3 },
                new GameGenre { GameId = 3, GenreId = 4 },
                new GameGenre { GameId = 3, GenreId = 5 },
                new GameGenre { GameId = 3, GenreId = 7 },
                new GameGenre { GameId = 3, GenreId = 9 },
                new GameGenre { GameId = 3, GenreId = 12 }
                );

        }
    }
}
