using EFGameAPI.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace EFGameAPI.DAL.Models
{
    public class GameCreate
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Resume { get; set; }
        [Required]
        public List<int> GenreIds { get; set; }
    }
}
