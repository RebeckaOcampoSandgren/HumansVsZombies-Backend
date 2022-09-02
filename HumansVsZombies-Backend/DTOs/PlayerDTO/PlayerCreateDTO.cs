using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.PlayerDTO
{
    public class PlayerCreateDTO
    {
        public bool IsHuman { get; set; }
        public bool IsPatientZero { get; set; }
        public int BiteCode { get; set; }
        public int GameId { get; set; }
        public int UserId { get; set; }
    }
}
