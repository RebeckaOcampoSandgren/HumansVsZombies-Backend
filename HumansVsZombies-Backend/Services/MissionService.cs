using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public class MissionService : IMissionService
    {
        private readonly HvZDbContext _context;

        public MissionService(HvZDbContext context)
        {
            _context = context;
        }

        public Task<Mission> AddChatAsync(Mission mission)
        {
            throw new NotImplementedException();
        }

        public Task DeleteMissionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Mission>> GetAllMissionsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Mission> GetMissionAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool MissionExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateMissionAsync(Mission mission)
        {
            throw new NotImplementedException();
        }
    }
}
