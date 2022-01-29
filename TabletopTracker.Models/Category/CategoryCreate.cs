using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Models.Category
{
    public class CategoryCreate
    {
        [Required]
        [MinLength(2, ErrorMessage = "The category name must contain at least 2 characters.")]
        [MaxLength(50, ErrorMessage = "The category name cannot contain more than 50 characters.")]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Description { get; set; }
    }
}
