using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Mission> AddMissionAsync(Mission mission)
        {
            _context.Mission.Add(mission);
            await _context.SaveChangesAsync();
            return mission;
        }

        public async Task DeleteMissionAsync(int id)
        {
            var character = await _context.Mission.FindAsync(id);
            _context.Mission.Remove(character);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Mission>> GetAllMissionsAsync()
        {
            return await _context.Mission.ToListAsync();
        }

        public async Task<IEnumerable<Mission>> GetAllMissionsInGameAsync(int gameId)
        {
            return await _context.Mission.Where(m => m.GameId == gameId).ToListAsync();
        }

        public async Task<Mission> GetMissionAsync(int id)
        {
            return await _context.Mission.FindAsync(id);
        }

        public async Task<Mission> GetOneMissionInGameAsync(int gameId, int missionId)
        {
            return await _context.Mission.FirstOrDefaultAsync(m => m.GameId == gameId && m.MissionId == missionId);
        }

        public bool MissionExists(int id)
        {
            return _context.Mission.Any(e => e.MissionId == id);
        }

        public async Task UpdateMissionAsync(Mission mission)
        {
            _context.Entry(mission).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
