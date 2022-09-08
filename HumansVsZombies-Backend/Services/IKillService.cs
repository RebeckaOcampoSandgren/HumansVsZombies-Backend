using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public interface IKillService
    {
       // public Task<IEnumerable<Kill>> GetAllKillsAsync();
       // public Task<Kill> GetKillAsync(int id);
        public Task<Kill> AddKillAsync(Kill kill);
        public Task UpdateKillAsync(Kill kill);
        public Task DeleteKillAsync(int id);
        public bool KillExists(int id);
    }
}
