using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Data
{
    public class Publisher
    {
        [Key]
        public int PublisherId { get; set; }
        [Required]
        public Guid OwnerId { get; set; }
        [Required]
        [MinLength(2, ErrorMessage = "The publisher name must contain at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "The publisher name cannot contain more than 50 characters.")]
        public string Name { get; set; }
        [DataType(DataType.Url)]
        public string Website { get; set; }

        public virtual ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
