using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public interface IGameService
    {
        public Task<IEnumerable<Game>> GetAllGamesAsync();
        public Task<Game> GetGameAsync(int id);
        public Task<Game> AddGameAsync(Game game);
        public Task UpdateGameAsync(Game game);
        public Task DeleteGameAsync(int id);
        public Task<Player> GetOnePlayerInGameAsync(int gameId, int playerId);
        public Task<IEnumerable<Player>> GetAllPlayersInGameAsync(int id);
        public bool GameExists(int id);
    }
}
