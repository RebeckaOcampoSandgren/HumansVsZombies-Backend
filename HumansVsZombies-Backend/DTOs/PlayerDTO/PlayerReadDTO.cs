using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.PlayerDTO
{
    public class PlayerReadDTO
    {
        public int PlayerId { get; set; }
        public bool IsHuman { get; set; }
        public bool IsPatientZero { get; set; }
        public int BiteCode { get; set; }
        public int Game { get; set; }
        public int User { get; set; }
        public int SquadMember { get; set; }
        public List<int> Chats { get; set; }
    }
}
