using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public class KillService : IKillService
    {
        private readonly HvZDbContext _context;

        public KillService(HvZDbContext context)
        {
            _context = context;
        }

        public async Task<Kill> AddKillAsync(Kill kill)
        {
            _context.Kill.Add(kill);
            await _context.SaveChangesAsync();
            return kill;
        }

        public async Task DeleteKillAsync(int id)
        {
            var kill = await _context.Kill.FindAsync(id);
            _context.Kill.Remove(kill);
            await _context.SaveChangesAsync();
        }

        public bool KillExists(int id)
        {
            return _context.Kill.Any(e => e.KillId == id);
        }

        //public async Task<IEnumerable<Kill>> GetAllKillsAsync()
        //{
            
        //}

        //public async Task<Kill> GetKillAsync(int id)
        //{
            
        //}

        public async Task UpdateKillAsync(Kill kill)
        {
            _context.Entry(kill).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
