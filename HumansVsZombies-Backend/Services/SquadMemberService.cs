using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public class SquadMemberService : ISquadMemberService
    {
        private readonly HvZDbContext _context;

        public SquadMemberService(HvZDbContext context)
        {
            _context = context;
        }

        public async Task<SquadMember> AddSquadMemberAsync(SquadMember squadMember)
        {
            _context.SquadMember.Add(squadMember);
            await _context.SaveChangesAsync();
            return squadMember;
        }

        public async Task DeleteSquadMemberAsync(int id)
        {
            var squadMember = await _context.SquadMember.FindAsync(id);
            _context.SquadMember.Remove(squadMember);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<SquadMember>> GetAllSquadMembersAsync()
        {
            return await _context.SquadMember.Include(smsc => smsc.SquadCheckins).ToListAsync();
        }

        public async Task<SquadMember> GetSquadMemberAsync(int id)
        {
            return await _context.SquadMember.Include(smsc => smsc.SquadCheckins).FirstOrDefaultAsync(s => s.SquadMemberId == id);

        }

        public bool SquadMemberExists(int id)
        {
            return _context.SquadMember.Any(e => e.SquadMemberId == id);
        }

        public async Task UpdateSquadMemberAsync(SquadMember squadMember)
        {
            _context.Entry(squadMember).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
