using EFGameAPI.DAL.Interfaces;
using EFGameAPI.DAL.Tools;
using EFGameAPI.DB.Entities;
using EFGameAPI.Models;
using EFGameAPI.Tools;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;

namespace EFGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly TokenManager _tokenManager;

        public UserController(IUserService userService, TokenManager tokenManager)
        {
            _userService = userService;
            _tokenManager = tokenManager;

        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] UserRegister register)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                string hash = BCrypt.Net.BCrypt.HashPassword(register.Password);
                _userService.Register(register.Email, hash, register.Username);
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [HttpPost("login")]
        public IActionResult Login([FromBody] UserLogin login)
        {
            if (!ModelState.IsValid) return BadRequest();


            try
            {
                if (!BCrypt.Net.BCrypt.Verify(login.Password, _userService.CheckPassword(login.Email))) return BadRequest("Invalid password");

                User user = _userService.Login(login.Email);

                return Ok(_tokenManager.GenerateToken(user));
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [Authorize("IsConnected")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (_userService.GetById(id) is null) return NotFound();

            return Ok(_userService.GetById(id).ToDTO<UserDTO, User>());
        }

        [Authorize("AdminPolicy")]
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_userService.GetAll().ToDTO<UserDTO, User>());
        }
        [Authorize("AdminPolicy")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                _userService.Models.Remove(_userService.GetById(id));
                _userService.Context.SaveChanges();
                return Ok();
            }
            catch (Exception ex) { return BadRequest(ex.Message); }
        }
        [Authorize("AdminPolicy")]
        [HttpPatch("setRole")]
        public IActionResult SetRole(SetRoleForm set)
        {
            _userService.SetRole(set.UserId, set.RoleId);
            return Ok();
        }

        
    }
}
