using EFGameAPI.DAL;
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
        private readonly IDataAccess _dataAccess;
        private readonly DataContext _context;
        private readonly DbSet<Game> _games;
        private readonly List<GameDTO> _gamesList;
        public GameController(IDataAccess dataAccess)
        {
            _dataAccess = dataAccess;
            _context = _dataAccess.DataContext;
            _games = _context.Games;
            _gamesList = _games.Include(x => x.Genres).ThenInclude(x => x.Genre).ToList().ToDTO();
        }
        [HttpGet]
        public IActionResult Get()
        {

            return Ok(_gamesList);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            GameDTO game = _gamesList.Where(x => x.Id == id).FirstOrDefault();

            if (game is null)
                return NotFound();

            return Ok(game);
        }
        [HttpGet("genre/{id}")]
        public IActionResult GetByGenre(int id)
        {
            List<GameDTO> games = _gamesList.Where(x => x.Genres.Any(g => g.Id == id)).ToList();

            if (games is null)
                return NotFound();

            return Ok(games);
        }
        [HttpPost]
        public IActionResult Post([FromBody] GameCreate newGame)
        {
            if (!ModelState.IsValid) { return BadRequest(); }
            try
            {
                int lastId = _games.OrderByDescending(x => x.Id).FirstOrDefault()?.Id + 1 ?? 1;
                _games.Add(new Game { Id = lastId, Title = newGame.Title, Resume = newGame.Resume });
                _context.SaveChanges();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
