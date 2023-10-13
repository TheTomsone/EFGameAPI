using EFGameAPI.DAL.Interfaces;
using EFGameAPI.DB.Domain;
using EFGameAPI.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DAL.Services
{
    public class GenreService : BaseCrudable<Genre>, IGenreService
    {
        public GenreService(DataContext dataContext) : base(dataContext)
        {
        }
    }
}
