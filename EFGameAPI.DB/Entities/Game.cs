using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DB.Entities
{
    public class Game : IEntity
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Resume { get; set; }
        public List<GameGenre> Genres { get; set; }
        public List<UserGame> Users { get; set; }
    }
}
