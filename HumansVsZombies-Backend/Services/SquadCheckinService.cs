using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public class SquadCheckinService : ISquadCheckinService
    {
        private readonly HvZDbContext _context;

        public SquadCheckinService(HvZDbContext context)
        {
            _context = context;
        }

        public Task<SquadCheckin> AddSquadCheckinAsync(SquadCheckin squadCheckin)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSquadCheckinAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SquadCheckin>> GetAllSquadCheckinsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SquadCheckin> GetSquadCheckinAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool SquadCheckinExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSquadCheckinAsync(SquadCheckin squadCheckin)
        {
            throw new NotImplementedException();
        }
    }
}
