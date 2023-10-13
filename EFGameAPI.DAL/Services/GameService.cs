using EFGameAPI.DAL.Interfaces;
using EFGameAPI.DB.Domain;
using EFGameAPI.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DAL.Services
{
    public class GameService : BaseCrudable<Game>, IGameService
    {
        public GameService(DataContext dataContext) : base(dataContext)
        {
        }

        public bool AddFavorite(int userId, int gameId)
        {
            return Context.UsersGame.Add(new UserGame { UserId = userId, GameId = gameId }).IsKeySet;
        }
        public IEnumerable<Game> GetByGenre(int genreId)
        {
            return Models.Where(game => game.Genres.Any(genre => genre.GenreId == genreId));
        }
        public IEnumerable<Game> GetByUser(int userId)
        {
            return Models.Where(game => game.Users.Any(user => user.UserId == userId));
        }
    }
}
