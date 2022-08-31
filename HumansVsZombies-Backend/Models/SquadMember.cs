using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class SquadMember
    {
        //PK
        [Required]
        public int SquadMemberId { get; set; }
        [Required]
        public int Rank { get; set; }
        //Relationships
        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }
        [Required]
        public int SquadId { get; set; }
        public Squad Squad { get; set; }
        [Required]
        public int PlayerId { get; set; }
        public virtual ICollection<SquadCheckin> SquadCheckins { get; set; }


    }
}
