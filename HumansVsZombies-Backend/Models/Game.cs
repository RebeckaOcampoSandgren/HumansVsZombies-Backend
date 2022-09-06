using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class Game
    {
        //PK
        public int GameId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The name is too long")]
        public string GameName { get; set; }
        [Required]
        public string GameState { get; set; }
        public double? NwLat { get; set; }
        public double? NwLng { get; set; }
        public double? SeLat { get; set; }
        public double? SeLng { get; set; }
        //relationships one to many
        public virtual ICollection<Player> Players { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }
        public virtual ICollection<Squad> Squads { get; set; }
        public virtual ICollection<Mission> Missions { get; set; }
    }
}
