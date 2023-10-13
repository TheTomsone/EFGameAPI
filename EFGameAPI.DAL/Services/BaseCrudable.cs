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
    public class BaseCrudable<TModel> : BaseRepository<TModel>, IBaseCrudable<TModel> where TModel : class, IEntity
    {
        public BaseCrudable(DataContext dataContext) : base(dataContext)
        {
        }

        public bool Create(TModel model)
        {
            return Models.Add(model).IsKeySet;
        }
        public bool Delete(int id)
        {
            return !Models.Remove(GetById(id)).IsKeySet;
        }
    }
}
