using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Models.Game
{
    public class GameDetail
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Category")]
        public string Category { get; set; }
        public int? CategoryId { get; set; }
        [Display(Name = "Publisher")]
        public string Publisher { get; set; }
        public int? PublisherId { get; set; }
        [Display(Name = "Minimum Player Count")]
        public int MinPlayers { get; set; }
        [Display(Name = "Maximum Player Count")]
        public int MaxPlayers { get; set; }
        [Display(Name = "Played")]
        public bool HavePlayed { get; set; }
        public int Rating { get; set; }
    }
}
