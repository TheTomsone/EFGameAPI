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
            return Models.FirstOrDefault(x => x.Email == email).Password;
        }
        public User Login(string email)
        {
            return Models.First(x => x.Email == email);
        }
        public bool Register(string email, string pwd, string username)
        {
            try
            {
                Models.Add(new User { Id = NextId, Email = email, Password = pwd, Username = username, RoleId = 1 });
                Context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
        public bool SetRole(int idUser, int idRole)
        {
            try
            {
                Models.First(x => x.Id == idUser).RoleId = idRole;
                Context.SaveChanges();
                return true;
            }
            catch { return false; }
        }
    }
}
