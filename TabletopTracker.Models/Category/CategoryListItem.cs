using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Models.Category
{
    public class CategoryListItem
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        [Display(Name = "Games in Collection")]
        public int GameCount { get; set; }
    }
}
