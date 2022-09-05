using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<SquadCheckin> AddSquadCheckinAsync(SquadCheckin squadCheckin)
        {
            _context.SquadCheckin.Add(squadCheckin);
            await _context.SaveChangesAsync();
            return squadCheckin;
        }

        public async Task DeleteSquadCheckinAsync(int id)
        {
            var squadCheckin = await _context.SquadCheckin.FindAsync(id);
            _context.SquadCheckin.Remove(squadCheckin);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SquadCheckin>> GetAllSquadCheckinsAsync()
        {
            return await _context.SquadCheckin.ToListAsync();
        }

        public async Task<SquadCheckin> GetSquadCheckinAsync(int id)
        {
            return await _context.SquadCheckin.FirstOrDefaultAsync(s => s.SquadCheckinId == id);
        }

        public bool SquadCheckinExists(int id)
        {
            return _context.SquadCheckin.Any(e => e.SquadCheckinId == id);

        }

        public async Task UpdateSquadCheckinAsync(SquadCheckin squadCheckin)
        {
            _context.Entry(squadCheckin).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
