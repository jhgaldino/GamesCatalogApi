using ErrorOr;
using FluentValidation;
using GamesCatalogApi.Data;
using GamesCatalogApi.Dtos;
using GamesCatalogApi.Extensions;
using GamesCatalogApi.Models;
using Microsoft.EntityFrameworkCore;

namespace GamesCatalogApi.Services
{
    public class GameService : IGameService
    {
        private readonly GamesContext _context;
        private readonly IValidator<CreateGameRequest> _createGameRequestValidator;

        public GameService(GamesContext context,
            IValidator<CreateGameRequest> createGameRequestValidator)
        {
            _context = context;
            _createGameRequestValidator = createGameRequestValidator;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game?> GetGameByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public async Task<ErrorOr<CreateGameResponse>> AddGameAsync(CreateGameRequest request, CancellationToken cancellationToken)
        {
            var validationResult = _createGameRequestValidator.Validate(request);

            if (!validationResult.IsValid)
                return validationResult.Errors.ToValidation();

            var game = new Game
            {
                Title = request.Title,
                Developer = request.Developer,
                Genre = request.Genre,
                Publisher = request.Publisher
            };

            await _context.Games.AddAsync(game, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            // aqui vc pode usar uma biblioteca como o auto mapper por exemplo para não ficar repetindo muito.
            return new CreateGameResponse
            {
                Id = game.Id,
                Title = game.Title,
                Developer = game.Developer,
                Genre = game.Genre,
                Publisher = game.Publisher
            };
        }

        public async Task UpdateGameAsync(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game != null)
            {
                _context.Games.Remove(game);
                await _context.SaveChangesAsync();
            }
        }
    }

    public interface IGameService
    {
        Task<List<Game>> GetAllGamesAsync();
        Task<Game> GetGameByIdAsync(int id);
        Task<ErrorOr<CreateGameResponse>> AddGameAsync(CreateGameRequest request, CancellationToken cancellationToke);
        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(int id);
    }
}


