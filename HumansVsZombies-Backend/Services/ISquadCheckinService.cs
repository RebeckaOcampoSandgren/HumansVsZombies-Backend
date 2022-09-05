using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public interface ISquadCheckinService
    {
        public Task<IEnumerable<SquadCheckin>> GetAllSquadCheckinsAsync();
        public Task<SquadCheckin> GetSquadCheckinAsync(int id);
        public Task<SquadCheckin> AddSquadCheckinAsync(SquadCheckin squadCheckin);
        public Task UpdateSquadCheckinAsync(SquadCheckin squadCheckin);
        public Task DeleteSquadCheckinAsync(int id);
        public bool SquadCheckinExists(int id);
    }
}
