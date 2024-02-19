using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using GamesCatalogApi.Data;
using GamesCatalogApi.Models;
namespace GamesCatalogApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GamesController
    {
        private readonly GamesContext _context;
        public GamesController(GamesContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> Get()
        {
            return await _context.Games.ToListAsync();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Game>> GetById(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return new NotFoundResult();
            }
            return game;
        }
        [HttpPost]
        public async Task<ActionResult<Game>> Post([FromBody] Game game)
        {
            _context.Games.Add(game);
            await _context.SaveChangesAsync();
            return new CreatedAtRouteResult("GetGame", new { id = game.Id }, game);
        }
        [HttpPut("{id}")]
        public async Task<ActionResult<Game>> Put(int id, [FromBody] Game game)
        {
            if (id != game.Id)
            {
                return new BadRequestResult();
            }
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult<Game>> Delete(int id)
        {
            var game = await _context.Games.FindAsync(id);
            if (game == null)
            {
                return new NotFoundResult();
            }
            _context.Games.Remove(game);
            await _context.SaveChangesAsync();
            return new NoContentResult();
        }
    }
}
