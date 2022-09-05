using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
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

        public Task<Game> AddGameAsync(Game game)
        {
            throw new NotImplementedException();
        }

        public Task DeleteGameAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool GameExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Game>> GetAllGamesAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Game> GetGameAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateGameAsync(Game game)
        {
            throw new NotImplementedException();
        }
    }
}
