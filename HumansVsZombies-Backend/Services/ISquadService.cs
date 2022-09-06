using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public interface ISquadService
    {
        public Task<IEnumerable<Squad>> GetAllSquadsAsync();
        public Task<Squad> GetSquadAsync(int id);
        public Task<Squad> AddSquadAsync(Squad squad);
        public Task UpdateSquadAsync(Squad squad);
        public Task DeleteSquadAsync(int id);
        public Task<IEnumerable<Squad>> GetAllSquadsInGameAsync(int gameId);
        public Task<Squad> GetOneSquadInGameAsync(int gameId, int squadId);
        public Task<IEnumerable<Chat>> GetAllChatsInSquadAsync(int id);
        public Task<IEnumerable<SquadCheckin>> GetAllCheckinsInSquadAsync(int id);
        public bool SquadExists(int id);
    }
}
