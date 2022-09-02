using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.SquadCheckinDTO
{
    public class SquadCheckinCreateDTO
    {
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int GameId { get; set; }
        public int SquadId { get; set; }
        public int SquadMemberId { get; set; }
    }
}
