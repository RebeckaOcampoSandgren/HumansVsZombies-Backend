using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.SquadMemberDTO
{
    public class SquadMemberCreateDTO
    {
        public int Rank { get; set; }
        public int SquadId { get; set; }
        public int PlayerId { get; set; }

    }
}
