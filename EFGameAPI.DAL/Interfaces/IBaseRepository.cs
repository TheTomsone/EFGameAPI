using EFGameAPI.DB.Domain;
using EFGameAPI.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DAL.Interfaces
{
    public interface IBaseRepository<TModel> where TModel : class, IEntity
    {
        DataContext Context { get; }
        DbSet<TModel> Models { get; }
        IEnumerable<TModel> GetAll();
        TModel GetById(int id);
    }
}
