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
    public class BaseService
    {
        private readonly DataContext _dataContext;
        protected DataContext DataContext => _dataContext;
        public BaseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
    }
}
