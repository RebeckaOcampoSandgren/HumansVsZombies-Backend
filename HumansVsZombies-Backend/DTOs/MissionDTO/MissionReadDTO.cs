using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.MissionDTO
{
    public class MissionReadDTO
    {
        public int MissionId { get; set; }
        public string MissionName { get; set; }
        public bool IsHumanVisible { get; set; }
        public bool IsZombieVisible { get; set; }
        #nullable enable
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int Game { get; set; }
    }
}
