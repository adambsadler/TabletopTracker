using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTracker.Data;
using TabletopTracker.Models.Publisher;

namespace TabletopTracker.Services
{
    public class PublisherService
    {
        private readonly Guid _userId;

        public PublisherService(Guid userId)
        {
            _userId = userId;
        }

        public IEnumerable<PublisherListItem> GetPublishers()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Publishers
                        .Select(
                            e => new PublisherListItem
                            {
                                PublisherId = e.PublisherId,
                                Name = e.Name,
                                Website = e.Website,
                                GameCount = e.Games.Count

                            }
                        );

                return query.ToArray();
            }
        }
    }
}
