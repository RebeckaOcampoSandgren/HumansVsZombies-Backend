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
        public bool SquadExists(int id);
    }
}
