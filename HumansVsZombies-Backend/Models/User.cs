using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HumansVsZombies_Backend.Models
{
    public class User
    {
        //PK
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The name is too long")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50, ErrorMessage = "The name is too long")]
        public string LastName { get; set; }
        public bool IsAdmin { get; set; }
        //Relationship 
        public virtual ICollection<Player> Players { get; set; }

    }
}
