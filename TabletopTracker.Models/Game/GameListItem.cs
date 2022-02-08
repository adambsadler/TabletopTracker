using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Models.Game
{
    public class GameListItem
    {
        public int GameId { get; set; }
        public string Title { get; set; }
        [Display(Name = "Category")]
        public string CategoryName { get; set; }
        [Display(Name = "Publisher")]
        public string PublisherName { get; set; }
        [Display(Name = "Min. Players")]
        public int MinPlayers { get; set; }
        [Display(Name = "Max Players")]
        public int MaxPlayers { get; set; }
        [Display(Name = "Played")]
        public bool HavePlayed { get; set; }
        public int Rating { get; set; }
    }
}
