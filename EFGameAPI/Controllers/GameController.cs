using EFGameAPI.DAL;
using EFGameAPI.DAL.Interfaces;
using EFGameAPI.DAL.Models;
using EFGameAPI.DAL.Tools;
using EFGameAPI.DB.Domain;
using EFGameAPI.DB.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EFGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly IGameService _gameService;
        private readonly IEnumerable<Game> _gameList;
        public GameController(IGameService gameService)
        {
            _gameService = gameService;
            _gameList = _gameService.Models.Include(game => game.Genres).ThenInclude(gameGenre => gameGenre.Genre).ToList();
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_gameList.ToDTO<GameDTO, Game>());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (_gameService.GetById(id) is null)
                return NotFound();

            return Ok(_gameService.GetById(id).ToDTO<GameDTO, Game>());
        }
        [HttpGet("genre/{id}")]
        public IActionResult GetByGenre(int id)
        {
            if (_gameList.Where(x => x.Genres.Any(g => g.GenreId == id)) is null)
                return NotFound();

            return Ok(_gameList.Where(x => x.Genres.Any(g => g.GenreId == id)).ToDTO<GameDTO, Game>());
        }
        [HttpPost]
        public IActionResult Post([FromBody] GameCreate newGame)
        {
            try
            {
                int lastId = _gameList.OrderByDescending(x => x.Id).FirstOrDefault()?.Id + 1 ?? 1;
                if (_gameService.Create(newGame.ToEntity<Game, GameCreate>(lastId)))
                {
                    _gameService.Context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_gameService.Delete(id))
                {
                    _gameService.Context.SaveChanges();
                    return Ok();
                }
            }
            catch (Exception ex) { return BadRequest(ex.Message); }

            return NotFound();
        }
    }
}
