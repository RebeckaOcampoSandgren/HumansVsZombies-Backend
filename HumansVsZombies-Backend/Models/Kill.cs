using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class Kill
    {
        //PK
        [Key]
        public int KillId { get; set; }
        public DateTime TimeOfDeath { get; set; }
        #nullable enable
        public string? Story { get; set; }
        public double? Lat { get; set; }
        public double? Lng { get; set; }
        //relationships one to many
        public int GameId { get; set; }
        public Game Game { get; set; }
        public int KillerId { get; set; }
        public Player Killer { get; set; }
        public int VictimId { get; set; }
        public Player Victim { get; set; }
    }
}
