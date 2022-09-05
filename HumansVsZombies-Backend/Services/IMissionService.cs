using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public interface IMissionService
    {
        public Task<IEnumerable<Mission>> GetAllMissionsAsync();
        public Task<Mission> GetMissionAsync(int id);
        public Task<Mission> AddChatAsync(Mission mission);
        public Task UpdateMissionAsync(Mission mission);
        public Task DeleteMissionAsync(int id);
        public bool MissionExists(int id);

    }
}
