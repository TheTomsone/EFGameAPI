using EFGameAPI.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DAL.Interfaces
{
    public interface IBaseCrudable<TModel> where TModel : class, IEntity
    {
        bool Create(TModel model);
        bool Delete(int id);
    }
}
