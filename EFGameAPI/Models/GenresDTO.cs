using EFGameAPI.Interfaces;

namespace EFGameAPI.DAL.Models
{
    public class GenresDTO : IModelDTO
    {
        public int Id { get; set; }
        public string Label { get; set; }
    }
}
