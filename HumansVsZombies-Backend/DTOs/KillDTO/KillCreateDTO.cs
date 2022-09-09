using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.KillDTO
{
    public class KillCreateDTO
    {
        public DateTime TimeOfDeath { get; set; }
        #nullable enable
        public string? Story { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        public int GameId { get; set; }
        public int KillerId { get; set; }
        public int VictimId { get; set; }
        public int BiteCode { get; set; }
    }
}
