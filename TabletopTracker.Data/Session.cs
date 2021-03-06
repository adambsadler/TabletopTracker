using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Data
{
    public class Session
    {
        [Key]
        public int SessionId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [ForeignKey(nameof(Game))]
        [Display(Name = "Game Played")]
        public int? GameId { get; set; }
        public virtual Game Game { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTimeOffset Date { get; set; }
        [MaxLength(500)]
        public string Players { get; set; }
        [MaxLength(500)]
        public string Notes { get; set; }
    }
}
