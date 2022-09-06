using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public class PlayerService : IPlayerService
    {
        private readonly HvZDbContext _context;

        public PlayerService(HvZDbContext context)
        {
            _context = context;
        }

        public async Task<Player> AddPlayerAsync(Player player)
        {
            _context.Player.Add(player);
            await _context.SaveChangesAsync();
            return player;
        }

        public async Task DeletePlayerAsync(int id)
        {
            var player = await _context.Player.FindAsync(id);
            _context.Player.Remove(player);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            return await _context.Player.Include(pc => pc.Chats).ToListAsync();
        }

        public async Task<Player> GetPlayerAsync(int id)
        {
            return await _context.Player.Include(pc => pc.Chats).FirstOrDefaultAsync(pi => pi.PlayerId == id);
        }

        public bool PlayerExists(int id)
        {
            return _context.Player.Any(e => e.PlayerId == id);
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            _context.Entry(player).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task UpdatePlayerInGameAsync(Player player, int gameId, int playerId)
        {
            var playerToUpdate = _context.Player.Where(p => p.GameId == gameId && p.PlayerId == playerId).Single();
            _context.Entry(playerToUpdate).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
