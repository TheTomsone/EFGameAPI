﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EFGameAPI.DB.Entities
{
    public class User : IEntity
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public int RoleId { get; set; }
        public List<UserGame> Games { get; set; }
        public string Password { get; set; }
    }
}
