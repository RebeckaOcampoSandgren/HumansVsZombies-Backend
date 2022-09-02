using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.SquadMemberDTO
{
    public class SquadMemberReadDTO
    {
        public int SquadMemberId { get; set; }
        public int Rank { get; set; }
        public int Squad { get; set; }
        public int Player { get; set; }
        public List<int> SquadCheckins { get; set; }
    }
}
