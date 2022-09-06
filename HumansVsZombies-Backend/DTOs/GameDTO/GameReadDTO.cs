using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.DTOs.GameDTO
{
    public class GameReadDTO
    {
        public int GameId { get; set; }
        public string GameName { get; set; }
        public string GameState { get; set; }
        public double? NwLat { get; set; }
        public double? NwLng { get; set; }
        public double? SeLat { get; set; }
        public double? SeLng { get; set; }
        public List<int> Chats { get; set; }
        public List<int> Squads { get; set; }
        public List<int> Missions { get; set; }
        public List<int> Players { get; set; }

    }
}
