using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DB.Entities
{
    public class Genre
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public List<GameGenre> Games { get; set; }
    }
}
