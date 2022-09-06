using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.PlayerDTO
{
    public class PlayerUpdateDTO
    {
        public int PlayerId { get; set; }
        public bool IsHuman { get; set; }
        public bool IsPatientZero { get; set; }
        public int BiteCode { get; set; }
    }
}
