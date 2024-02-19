using GamesCatalogApi.Data;
using GamesCatalogApi.Models;
using Microsoft.EntityFrameworkCore;

    namespace GamesCatalogApi.Services
    {
    public class GameService : IGameService
    {
        private readonly GamesContext _context;

        public GameService(GamesContext context)
        {
            _context = context;
        }

        public async Task<List<Game>> GetAllGamesAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetGameByIdAsync(int id)
        {
            return await _context.Games.FindAsync(id);
        }

        public virtual async Task AddGameAsync(Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
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
        Task AddGameAsync(Game game);
        Task UpdateGameAsync(Game game);
        Task DeleteGameAsync(int id);
    }
}


