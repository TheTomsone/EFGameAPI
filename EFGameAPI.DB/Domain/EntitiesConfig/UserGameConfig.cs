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
    public class UserGameConfig : IEntityTypeConfiguration<UserGame>
    {
        public void Configure(EntityTypeBuilder<UserGame> builder)
        {
            builder.HasKey(nameof(UserGame.UserId), nameof(UserGame.GameId));

            builder.HasOne(x => x.User)
                    .WithMany(x => x.Games)
                    .HasForeignKey(x => x.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.Game)
                    .WithMany(x => x.Users)
                    .HasForeignKey(x => x.GameId)
                    .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
