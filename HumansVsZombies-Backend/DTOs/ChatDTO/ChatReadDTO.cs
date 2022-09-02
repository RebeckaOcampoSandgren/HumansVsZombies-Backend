using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.ChatDTO
{
    public class ChatReadDTO
    {
        public int ChatId { get; set; }
        public string Message { get; set; }
        public bool IsHumanGlobal { get; set; }
        public bool IsZombieGlobal { get; set; }
        public DateTime ChatTime { get; set; }
        public int Game { get; set; }
        public int Player { get; set; }
        public int? Squad { get; set; }
    }
}
