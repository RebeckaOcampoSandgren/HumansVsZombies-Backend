using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.ChatDTO
{
    public class ChatCreateDTO
    {
        public string Message { get; set; }
        public bool IsHumanGlobal { get; set; }
        public bool IsZombieGlobal { get; set; }
        public DateTime ChatTime { get; set; }
        public int GameId { get; set; }
        public int PlayerId { get; set; }
        public int? SquadId { get; set; }
    }
}
