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
        public int SquadId { get; set; }
        public Squad Squad { get; set; }
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        public virtual ICollection<SquadCheckin> SquadCheckins { get; set; }


    }
}
