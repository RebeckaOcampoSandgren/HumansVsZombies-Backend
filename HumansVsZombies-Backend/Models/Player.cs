using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class Player
    {
        //PK
        [Required]
        public int PlayerId { get; set; }
        [Required]
        public bool IsHuman { get; set; }
        [Required]
        public bool IsPatientZero { get; set; }
        [Required]
        public int BiteCode { get; set; }

        //Not sure about the relationship
        [Required]
        public int UserId { get; set; }
        public User User { get; set; }
        [Required]
        public int GameId { get; set; }
        public Game Game { get; set; }
        public virtual ICollection<Kill> Kills { get; set; }
        public virtual ICollection<Kill> Victims { get; set; }
        public virtual ICollection<Chat> Chats { get; set; }


    }
}
