using HumansVsZombies_Backend.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Services
{
    public interface ISquadMemberService
    {
        public Task<IEnumerable<SquadMember>> GetAllSquadMembersAsync();
        public Task<SquadMember> GetSquadMemberAsync(int id);
        public Task<SquadMember> AddSquadMemberAsync(SquadMember squadMember);
        public Task UpdateSquadMemberAsync(SquadMember squadMember);
        public Task DeleteSquadMemberAsync(int id);
        public bool SquadMemberExists(int id);
    }
}
