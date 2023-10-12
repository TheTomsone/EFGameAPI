using EFGameAPI.DB.Domain.EntitiesConfig;
using EFGameAPI.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DB.Domain
{
    public class DataContext : DbContext
    {
        private readonly string _connString = @"Data Source=DESKTOP-UGDKHCT;Initial Catalog=EFGameAPI.DB;Integrated Security=True;Connect Timeout=60;Encrypt=False;Trust Server Certificate=False;";

        public DbSet<Game> Games { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<GameGenre> GameGenres { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGame> UsersGame { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new GameConfig());
            modelBuilder.ApplyConfiguration(new GenreConfig());
            modelBuilder.ApplyConfiguration(new GameGenreConfig());
            modelBuilder.ApplyConfiguration(new UserConfig());
            modelBuilder.ApplyConfiguration(new UserGameConfig());
        }
    }
}
