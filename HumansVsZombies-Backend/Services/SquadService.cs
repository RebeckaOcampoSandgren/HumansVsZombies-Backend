using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Squad> AddSquadAsync(Squad squad)
        {
            _context.Squad.Add(squad);
            await _context.SaveChangesAsync();
            return squad;
        }

        public async Task DeleteSquadAsync(int id)
        {
            var squad = await _context.Squad.FindAsync(id);
            _context.Squad.Remove(squad);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Squad>> GetAllSquadsAsync()
        {
            return await _context.Squad.Include(ssm => ssm.SquadMembers).Include(ssc => ssc.SquadCheckins).Include(sc => sc.Chats).ToListAsync();
        }

        public async Task<Squad> GetSquadAsync(int id)
        {
            return await _context.Squad.Include(ssm => ssm.SquadMembers).Include(ssc => ssc.SquadCheckins).Include(sc => sc.Chats).FirstOrDefaultAsync(s => s.SquadId == id);

        }

        public bool SquadExists(int id)
        {
            return _context.Squad.Any(e => e.SquadId == id);
        }

        public async Task UpdateSquadAsync(Squad squad)
        {
            _context.Entry(squad).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
