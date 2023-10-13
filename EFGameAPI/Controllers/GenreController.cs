using EFGameAPI.DAL.Interfaces;
using EFGameAPI.DAL.Models;
using EFGameAPI.DAL.Tools;
using EFGameAPI.DB.Entities;
using EFGameAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFGameAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenreController : ControllerBase
    {
        private readonly IGenreService _genreService;
        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_genreService.Models.ToDTO<GenreDTO, Genre>());
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (_genreService.GetById(id) is null) return NotFound();

            return Ok(_genreService.GetById(id).ToDTO<GenreDTO, Genre>());
        }
        [HttpPost]
        public IActionResult Post([FromBody] GenreCreate newGenre)
        {
            Genre genre = newGenre.ToEntity<Genre, GenreCreate>(_genreService.NextId);

            try { if (_genreService.Create(genre)) return Ok(); }
            catch (Exception ex) { return BadRequest(ex.Message); }

            return BadRequest();
        }
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            try { if (_genreService.Delete(id)) return Ok(); }
            catch (Exception ex) { return BadRequest(ex.Message); }

            return NotFound();
        }
    }
}
