using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.SquadDTO
{
    public class SquadCreateDTO
    {
        public string SquadName { get; set; }
        public bool IsHuman { get; set; }
        public int GameId { get; set; }
    }
}
