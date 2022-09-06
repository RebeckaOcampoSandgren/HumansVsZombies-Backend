using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public class GameService : IGameService
    {
        private readonly HvZDbContext _context;

        public GameService(HvZDbContext context)
        {
            _context = context;
        }

        public async Task<Game> AddGameAsync(Game game)
        {
            _context.Game.Add(game);
            await _context.SaveChangesAsync();
            return game;
        }

        public async Task DeleteGameAsync(int id)
        {
            var game = await _context.Game.FindAsync(id);
            _context.Game.Remove(game);
            await _context.SaveChangesAsync();
        }

        public bool GameExists(int id)
        {
            return _context.Game.Any(e => e.GameId == id);
        }

        public async Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            return await _context.Game.Include(gc => gc.Chats).Include(gs => gs.Squads).Include(gm => gm.Missions).Include(gp => gp.Players).ToListAsync();
        }

        public async Task<IEnumerable<Player>> GetAllPlayersInGameAsync(int id)
        {
            return await _context.Game.Where(g => g.GameId == id).SelectMany(g => g.Players).ToListAsync();
        }

        public async Task<Game> GetGameAsync(int id)
        {
            return await _context.Game.Include(gc => gc.Chats).Include(gs => gs.Squads).Include(gm => gm.Missions).Include(gp => gp.Players).FirstOrDefaultAsync(gi => gi.GameId == id);
        }
        public async Task<Player> GetOnePlayerInGameAsync(int gameId, int playerId)
        {
            return await _context.Player.Include(pc => pc.Chats).FirstOrDefaultAsync(p => p.GameId == gameId && p.PlayerId == playerId);
        }

        public async Task UpdateGameAsync(Game game)
        {
            _context.Entry(game).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
