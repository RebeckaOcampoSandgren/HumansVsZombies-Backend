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
        public Task<Mission> AddMissionAsync(Mission mission);
        public Task UpdateMissionAsync(Mission mission);
        public Task DeleteMissionAsync(int id);
        public Task<IEnumerable<Mission>> GetAllMissionsInGameAsync(int gameId);
        public Task<Mission> GetOneMissionInGameAsync(int gameId, int missionId);
        public bool MissionExists(int id);

    }
}
