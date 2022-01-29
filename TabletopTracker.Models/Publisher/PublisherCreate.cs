using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Models.Publisher
{
    public class PublisherCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "The publisher name must contain at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "The publisher name cannot contain more than 50 characters.")]
        public string Name { get; set; }
        [DataType(DataType.Url)]
        public string Website { get; set; }
    }
}
