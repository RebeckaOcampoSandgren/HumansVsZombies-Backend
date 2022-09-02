using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class Chat
    {
        //PK
        public int ChatId { get; set; }
        [Required]
        [MaxLength(800, ErrorMessage = "The message is too long")]
        public string Message { get; set; }
        [Required]
        public bool IsHumanGlobal { get; set; }
        [Required]
        public bool IsZombieGlobal { get; set; }
        [Required]
        public DateTime ChatTime { get; set; }

        //Relationship one-to-many
        [Required]
        [ForeignKey("GameId")]
        public int GameId { get; set; }
        public Game Game { get; set; }
        [ForeignKey("PlayerId")]
        public int PlayerId { get; set; }
        public Player Player { get; set; }
        [ForeignKey("SquadId")]
        public int? SquadId { get; set; }
        public Squad Squad { get; set; }

    }
}
