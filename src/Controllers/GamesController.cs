using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GamesCatalogApi.Models;
using GamesCatalogApi.Services;
using GamesCatalogApi.Dtos;

namespace GamesCatalogApi.Controllers
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
        public async Task<ActionResult<Game>> Post([FromBody] CreateGameRequest request, CancellationToken cancellationToken)
        {

            var result = await _gameService.AddGameAsync(request, cancellationToken);

            // Você pode criar uma extensão por exemplo para ficar mais fácil de ler e escrever o código nessa parte de verificar se o erro é do tipo validação.s
            if (result.FirstError.Type == ErrorOr.ErrorType.Validation)
                // Você pode criar uma extensão que formata o erro de acordo com o formato que você precisa por exemplo, tente usar problem details, é um padrão conhecido.s
                return BadRequest(result.Errors);

            return CreatedAtRoute("GetGame", new { id = result.Value.Id }, result.Value); // Usar método CreatedAtRoute()
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Game game)
         {
            // Essa validação não é necessária, vc só precisa validar se existe, se não existir você retorna not found.
            // A melhor opção aqui é criar um dto para o request sem o id, você considera que o id é o que vem da url e pronto.
            if (id != game.Id)
            {
                return BadRequest(); // Usar método BadRequest()
            }
            await _gameService.UpdateGameAsync(game); // Presumindo que existe um método UpdateGameAsync
            return NoContent(); // Usar método NoContent()
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var game = await _gameService.GetGameByIdAsync(id);
            if (game == null)
            {
                return NotFound(); // Usar método NotFound()
            }
            await _gameService.DeleteGameAsync(id); // Presumindo que existe um método DeleteGameAsync
            return NoContent(); // Usar método NoContent()
        }
    }
}