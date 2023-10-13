using EFGameAPI.Interfaces;

namespace EFGameAPI.DAL.Models
{
    public class GenreDTO : IModelDTO
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
