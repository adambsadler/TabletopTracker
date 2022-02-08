using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Models.Session
{
    public class SessionDetail
    {
        public int SessionId { get; set; }
        [Display(Name = "Game Played")]
        public string Game { get; set; }
        public int? GameId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Players { get; set; }
        public string Notes { get; set; }
    }
}
