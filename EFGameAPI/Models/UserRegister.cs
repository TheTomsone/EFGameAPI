using System.ComponentModel.DataAnnotations;

namespace EFGameAPI.Models
{
    public class UserRegister
    {
        [Required]
        [MinLength(3, ErrorMessage = "At least 3 Characters")]
        public string Username { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [DataType(DataType.Password)]
        [RegularExpression("^(?=.*[A-Za-z])(?=.*\\d)(?=.*[@$!%*#?&])[A-Za-z\\d@$!%*#?&]{8,}$")]
        public string Password { get; set; }
    }
}
