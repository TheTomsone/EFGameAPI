using EFGameAPI.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DAL.Interfaces
{
    public interface IGameService : IBaseRepository<Game>, IBaseCrudable<Game>
    {
        IEnumerable<Game> GetByGenre(int genreId);
        IEnumerable<Game> GetByUser(int userId);
        bool AddGenre(int gameId, int genreId);
        bool AddFavorite(int userId, int gameId);
    }
}
