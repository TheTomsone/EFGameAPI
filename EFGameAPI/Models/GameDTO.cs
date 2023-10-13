using EFGameAPI.Interfaces;

namespace EFGameAPI.DAL.Models
{
    public class GameDTO : IModelDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Resume { get; set; }
        public List<GenresDTO> Genres { get; set; }
    }
}
