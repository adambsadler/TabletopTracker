using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTracker.Data;
using TabletopTracker.Models.Game;

namespace TabletopTracker.Services
{
    public class GameService
    {
        private readonly Guid _userId;

        public GameService(Guid userId)
        {
            _userId = userId;
        }
        public bool CreateGame(GameCreate model)
        {
            var entity =
                new Game()
                {
                    OwnerId = _userId,
                    Title = model.Title,
                    PublisherId = model.PublisherId,
                    CategoryId = model.CategoryId,
                    MinPlayers = model.MinPlayers,
                    MaxPlayers = model.MaxPlayers,
                    HavePlayed = model.HavePlayed,
                    Rating = model.Rating
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Games.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<GameListItem> GetGames()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx.Games.Where(e => e.OwnerId == _userId)
                        .Select(e => new GameListItem
                                {
                                    GameId = e.GameId,
                                    Title = e.Title,
                                    PublisherName = e.Publisher.Name,
                                    CategoryName = e.Category.Name,
                                    MinPlayers = e.MinPlayers,
                                    MaxPlayers = e.MaxPlayers,
                                    HavePlayed = e.HavePlayed,
                                    Rating = e.Rating
                                }
                         );

                return query.ToArray();
            }
        }

        public GameDetail GetGameById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Games.Single(e => e.GameId == id && e.OwnerId == _userId);
                return new GameDetail
                {
                    GameId = entity.GameId,
                    Title = entity.Title,
                    CategoryId = entity.CategoryId,
                    PublisherId = entity.PublisherId,
                    MinPlayers = entity.MinPlayers,
                    MaxPlayers = entity.MaxPlayers,
                    HavePlayed = entity.HavePlayed,
                    Rating = entity.Rating
                };
            }
        }

        public bool UpdateGame(GameEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Games.Single(e => e.GameId == model.GameId && e.OwnerId == _userId);

                entity.Title = model.Title;
                entity.PublisherId = model.PublisherId;
                entity.CategoryId = model.CategoryId;
                entity.MinPlayers = model.MinPlayers;
                entity.MaxPlayers = model.MaxPlayers;
                entity.HavePlayed = model.HavePlayed;
                entity.Rating = model.Rating;

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
