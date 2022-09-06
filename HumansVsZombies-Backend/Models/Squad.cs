using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class Squad
    {
        //PK
        public int SquadId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The name is too long")]
        public string SquadName { get; set; }
        [Required]
        public bool IsHuman { get; set; }
        //Relationships
        public int GameId { get; set; }
        public Game Game { get; set; }
        public virtual ICollection<SquadMember> SquadMembers { get; set; }
        public virtual ICollection<SquadCheckin> SquadCheckins { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }

    }
}
