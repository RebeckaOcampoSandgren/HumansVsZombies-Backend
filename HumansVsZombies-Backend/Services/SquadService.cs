using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public class SquadService : ISquadService
    {
        private readonly HvZDbContext _context;

        public SquadService(HvZDbContext context)
        {
            _context = context;
        }

        public Task<Squad> AddSquadAsync(Squad squad)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSquadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Squad>> GetAllSquadsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Squad> GetSquadAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool SquadExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSquadAsync(Squad squad)
        {
            throw new NotImplementedException();
        }
    }
}
