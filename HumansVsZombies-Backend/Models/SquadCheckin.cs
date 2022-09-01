using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class SquadCheckin
    {
        //PK
        public int SquadCheckinId { get; set; }
        [Required]
        public DateTime StartTime { get; set; }
        [Required]
        public DateTime EndTime { get; set; }
        [Required]
        public double Lat { get; set; }
        [Required]
        public double Lng { get; set; }
        //Unsure about relationships
        public int GameId { get; set; }
        [ForeignKey("GameId")]
        public Game Game { get; set; }
        public int SquadId { get; set; }
        [ForeignKey("SquadId")]
        public Squad Squad { get; set; }
        public int SquadMemberId { get; set; }
        [ForeignKey("SquadMemberId")]
        public SquadMember SquadMember { get; set; }

    }
}
