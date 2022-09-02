using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.SquadDTO
{
    public class SquadReadDTO
    {
        public int SquadId { get; set; }
        public string SquadName { get; set; }
        public bool IsHuman { get; set; }
        public int Game { get; set; }
        public List<int> SquadMembers { get; set; }
        public List<int> SquadCheckins { get; set; }
        public List<int> Chats { get; set; }
    }
}
