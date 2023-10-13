using EFGameAPI.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFGameAPI.DAL.Interfaces
{
    public interface IUserService : IBaseRepository<User>
    {
        User Login(string email);
        bool Register(string email, string pwd, string username);
        bool SetRole(int idUser, int idRole);
        string CheckPassword(string email);
    }
}
