using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamesCatalogApi.src.Models;
using GamesCatalogApi.src.Services;
using GamesCatalogApi.src.Dtos;

namespace GamesCatalogApi.src.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController : ControllerBase // Herdar de ControllerBase
    {
        private readonly IGameService _gameService;

        public GamesController(IGameService gameService) // O construtor deve aceitar GameService
        {
            _gameService = gameService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> Get()
        {
            return Ok(await _gameService.GetAllGamesAsync()); // Envolver o resultado em Ok()
        }

        [HttpGet("{id}", Name = "GetGame")]
        public async Task<ActionResult<Game>> GetById(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound(); // Usar método NotFound()
            }
            return game;
        }

        [HttpPost]
        public async Task<ActionResult<Game>> Post([FromBody] Game game)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _gameService.AddGameAsync(game);
            return CreatedAtRoute("GetGame", new { id = game.Id }, game);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] GameUpdateRequestDto gameDto)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            game.Title = gameDto.Title;
            game.Genre = gameDto.Genre;
            game.Developer = gameDto.Developer;
            game.Publisher = gameDto.Publisher;

            await _gameService.UpdateGameAsync(game);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound();
            }
            await _gameService.DeleteGameAsync(id);
            return NoContent();
        }
    }
}