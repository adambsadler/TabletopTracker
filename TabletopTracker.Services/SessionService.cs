using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTracker.Data;
using TabletopTracker.Models.Session;

namespace TabletopTracker.Services
{
    public class SessionService
    {
        private readonly Guid _userId;

        public SessionService(Guid userId)
        {
            _userId = userId;
        }

        public bool CreateSession(SessionCreate model)
        {
            var entity =
                new Session()
                {
                    OwnerId = _userId,
                    GameId = model.GameId,
                    Date = model.Date,
                    Players = model.Players,
                    Notes = model.Notes
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Sessions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public IEnumerable<SessionListItem> GetSessions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Sessions
                        .Select(
                            e => new SessionListItem
                            {
                                SessionId = e.SessionId,
                                Game = e.Game.Title,
                                Date = e.Date,
                                Players = e.Players,
                                Notes = e.Notes
                            }
                        );

                return query.ToArray();
            }
        }

        public SessionDetail GetSessionById(int id)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx.Sessions.Single(e => e.SessionId == id && e.OwnerId == _userId);
                return new SessionDetail
                {
                    SessionId = entity.SessionId,
                    Date = entity.Date,
                    Players = entity.Players,
                    Notes = entity.Notes
                };
            }
        }

        public bool UpdateSession(SessionEdit model)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sessions.Single(e => e.SessionId == model.SessionId && e.OwnerId == _userId);

                entity.GameId = model.GameId;
                entity.Date = model.Date;
                entity.Players = model.Players;
                entity.Notes = model.Notes;

                return ctx.SaveChanges() == 1;
            }
        }

        public bool DeleteSession(int sessionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity = ctx.Sessions.Single(e => e.SessionId == sessionId && e.OwnerId == _userId);
                var games = new SessionService(_userId).GetSessions();

                ctx.Sessions.Remove(entity);

                return ctx.SaveChanges() == 1;
            }
        }
    }
}
