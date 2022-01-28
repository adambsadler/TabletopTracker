using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Data
{
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The game title must contain at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "The game title cannot contain more than 50 characters.")]
        public string Title { get; set; }
        [ForeignKey(nameof(Publisher))]
        public int? PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        [ForeignKey(nameof(Category))]
        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [Display(Name = "Minimum Players")]
        public int MinPlayers { get; set; }
        [Display(Name = "Maximum Players")]
        public int MaxPlayers { get; set; }
        [Display(Name = "Played")]
        public bool HavePlayed { get; set; }
        [Range(1, 10)]
        public int Rating { get; set; }
    }
}
