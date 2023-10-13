using EFGameAPI.DAL.Models;
using EFGameAPI.Interfaces;

namespace EFGameAPI.Models
{
    public class UserDTO : IModelDTO
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
        public List<GameDTO> Games { get; set; }
    }
}
