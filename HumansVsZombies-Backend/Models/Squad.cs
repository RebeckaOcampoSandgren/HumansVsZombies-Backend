using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class Squad
    {
        //PK
        [Required]
        public int SquadId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The name is too long")]
        public string Name { get; set; }
        [Required]
        public bool IsHuman { get; set; }
        //Relationships
        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }
        public virtual ICollection<SquadMember> SquadMembers { get; set; }
        public virtual ICollection<SquadCheckin> SquadCheckins { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }

    }
}
