using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class Mission
    {        
        //PK
        public int MissionId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The name is too long")]
        public string MissionName { get; set; }
        [Required]
        public bool IsHumanVisible { get; set; }
        [Required]
        public bool IsZombieVisible { get; set; }
        #nullable enable
        public string? Description { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        //Relationship one-to-many
        public int GameId { get; set; }
        public Game Game { get; set; }

    }
}
