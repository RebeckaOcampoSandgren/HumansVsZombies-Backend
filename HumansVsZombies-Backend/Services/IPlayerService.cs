using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public interface IPlayerService
    {
        public Task<IEnumerable<Player>> GetAllPlayersAsync();
        public Task<Player> GetPlayerAsync(int id);
        public Task<Player> AddPlayerAsync(Player player);
        public Task UpdatePlayerAsync(Player player);
        public Task DeletePlayerAsync(int id);
        public bool PlayerExists(int id);
        public Task UpdatePlayerInGameAsync(Player player, int gameId, int playerId);
    }
}
