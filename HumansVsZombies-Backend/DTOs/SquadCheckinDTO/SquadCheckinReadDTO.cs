using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.SquadCheckinDTO
{
    public class SquadCheckinReadDTO
    {
        public int SquadCheckinId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Game { get; set; }
        public int Squad { get; set; }
        public int SquadMember { get; set; }
    }
}
