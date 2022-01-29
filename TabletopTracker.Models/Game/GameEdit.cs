using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Models.Game
{
    public class GameEdit
    {
        public int GameId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The game title must contain at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "The game title cannot contain more than 50 characters.")]
        public string Title { get; set; }
        [Display(Name = "Publisher")]
        public int? PublisherId { get; set; }
        [Display(Name = "Category")]
        public int? CategoryId { get; set; }
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
