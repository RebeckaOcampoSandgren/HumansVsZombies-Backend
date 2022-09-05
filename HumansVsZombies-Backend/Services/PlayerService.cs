using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
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

        public Task<Player> AddPlayerAsync(Player player)
        {
            throw new NotImplementedException();
        }

        public Task DeletePlayerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Player> GetPlayerAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool PlayerExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdatePlayerAsync(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
