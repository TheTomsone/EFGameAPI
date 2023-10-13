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
    public class UserService : BaseRepository<User>, IUserService
    {
        public UserService(DataContext dataContext) : base(dataContext)
        {
        }

        public string CheckPassword(string email)
        {
            throw new NotImplementedException();
        }
        public User Login(string email)
        {
            throw new NotImplementedException();
        }
        public bool Register(string email, string pwd, string username)
        {
            throw new NotImplementedException();
        }
        public void SetRole(int idUser, int idRole)
        {
            throw new NotImplementedException();
        }
    }
}
