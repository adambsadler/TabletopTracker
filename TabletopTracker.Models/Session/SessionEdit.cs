using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Models.Session
{
    public class SessionEdit
    {
        public int SessionId { get; set; }
        [Display(Name = "Game Played")]
        public int? GameId { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Date { get; set; }
        [MaxLength(500)]
        public string Players { get; set; }
        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
