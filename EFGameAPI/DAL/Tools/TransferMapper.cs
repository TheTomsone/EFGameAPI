using EFGameAPI.DAL.Models;
using EFGameAPI.DB.Entities;

namespace EFGameAPI.DAL.Tools
{
    public static class TransferMapper
    {
        public static List<GameDTO> ToDTO(this List<Game> games)
        {
            List<GameDTO> gameDTOs = new();

            foreach (Game game in games) gameDTOs.Add(game.ToDTO());

            return gameDTOs;
        }
        private static GameDTO ToDTO(this Game game)
        {
            return new GameDTO
            {
                Id = game.Id,
                Title = game.Title,
                Resume = game.Resume,
                Genres = game.Genres.ToDTO(),
            };
        }
        public static GenresDTO ToDTO(this Genre genres)
        {
            return new GenresDTO
            {
                Id = genres.Id,
                Label = genres.Label,
            };
        }
        private static List<GenresDTO> ToDTO(this List<GameGenre> gameGenre)
        {
            List<GenresDTO> genres = new List<GenresDTO>();

            foreach (GameGenre item in gameGenre)
            {
                genres.Add(new GenresDTO { Id = item.Genre.Id, Label = item.Genre.Label });
            }

            return genres;
        }
    }
}
