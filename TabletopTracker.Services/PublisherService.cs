using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTracker.Data;
using TabletopTracker.Models.Game;
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

        public bool CreatePublisher(PublisherCreate model)
        {
            var entity =
                new Publisher()
                {
                    OwnerId = _userId,
                    Name = model.Name,
                    Website = model.Website
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Publishers.Add(entity);
                return ctx.SaveChanges() == 1;
            }
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

        public PublisherDetail GetPublisherById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Publishers.Single(e => e.PublisherId == id && e.OwnerId == _userId);
                return new PublisherDetail
                {
                    PublisherId = entity.PublisherId,
                    Name = entity.Name,
                    Website = entity.Website
                };
            }
        }

        public bool UpdatePublisher(PublisherEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers.Single(e => e.PublisherId == model.PublisherId && e.OwnerId == _userId);

                entity.Name = model.Name;
                entity.Website = model.Website;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeletePublisher(int publisherId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Publishers.Single(e => e.PublisherId == publisherId && e.OwnerId == _userId);
                var games = new GameService(_userId).GetGames();

                foreach (GameListItem game in games)
                {
                    var affectedGame = ctx.Games.Single(a => a.GameId == game.GameId);
                    if (affectedGame.PublisherId == publisherId)
                    {
                        affectedGame.PublisherId = null;
                    }
                }

                ctx.Publishers.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
