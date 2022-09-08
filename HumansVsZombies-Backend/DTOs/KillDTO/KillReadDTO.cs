using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.KillDTO
{
    public class KillReadDTO
    {
        public int KillId { get; set; }
        public DateTime TimeOfDeath { get; set; }
        public string Story { get; set; }
        public double Lat { get; set; }
        public double Lng { get; set; }
        public int Game { get; set; }
        public int Killer { get; set; }
        public int Victim { get; set; }
    }
}
