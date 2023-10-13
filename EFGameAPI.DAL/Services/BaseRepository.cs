using EFGameAPI.DAL.Interfaces;
using EFGameAPI.DB.Domain;
using EFGameAPI.DB.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DAL.Services
{
    public abstract class BaseRepository<TModel> : IBaseRepository<TModel> where TModel : class, IEntity
    {
        private readonly DataContext _dataContext;
        private readonly DbSet<TModel> _models;
        public DataContext Context => _dataContext;
        public DbSet<TModel> Models => _models;
        public BaseRepository(DataContext dataContext) { _dataContext = dataContext; _models = _dataContext.Set<TModel>(); }

        public IEnumerable<TModel> GetAll()
        {
            return Models;
        }
        public TModel GetById(int id)
        {
            return Models.FirstOrDefault(x => x.Id == id);
        }
    }
}
