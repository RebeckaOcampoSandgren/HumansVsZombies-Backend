using HumansVsZombies_Backend.Data;
using HumansVsZombies_Backend.Models;
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

        public Task<SquadMember> AddSquadMemberAsync(SquadMember squadMember)
        {
            throw new NotImplementedException();
        }

        public Task DeleteSquadMemberAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<SquadMember>> GetAllSquadMembersAsync()
        {
            throw new NotImplementedException();
        }

        public Task<SquadMember> GetSquadMemberAsync(int id)
        {
            throw new NotImplementedException();
        }

        public bool SquadMemberExists(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateSquadMemberAsync(SquadMember squadMember)
        {
            throw new NotImplementedException();
        }
    }
}
