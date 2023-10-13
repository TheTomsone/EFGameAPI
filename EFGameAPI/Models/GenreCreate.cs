using System.ComponentModel.DataAnnotations;

namespace EFGameAPI.Models
{
    public class GenreCreate
    {
        [Required]
        public string Label { get; set; }
    }
}
