using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTracker.Models.Publisher
{
    public class PublisherListItem
    {
        public int PublisherId { get; set; }
        public string Name { get; set; }
        public string Website { get; set; }
        [Display(Name = "Games in Collection")]
        public int GameCount { get; set; }
    }
}
