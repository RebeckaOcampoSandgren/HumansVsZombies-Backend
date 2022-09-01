using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class SquadMember
    {
        //PK
        public int SquadMemberId { get; set; }
        [Required]
        public int Rank { get; set; }
        //Relationships
        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }
       
        public int SquadId { get; set; }
        [ForeignKey("SquadId")]
        public Squad Squad { get; set; }
        public int PlayerId { get; set; }
        [ForeignKey("PlayerId")]
        public Player Player { get; set; }

        public virtual ICollection<SquadCheckin> SquadCheckins { get; set; }


    }
}
