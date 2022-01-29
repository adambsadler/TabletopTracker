using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TabletopTracker.Models.Game;
using TabletopTracker.Models.Session;
using TabletopTracker.Services;

namespace TabletopTracker.WebMVC.Controllers
{
    [Authorize]
    public class SessionController : Controller
    {
        // GET: Session
        public ActionResult Index()
        {
            var service = CreateSessionService();
            var model = service.GetSessions();
            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            ViewBag.Games = new SelectList(GetGames(), "GameId", "Title");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SessionCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateSessionService();

            if (service.CreateSession(model))
            {
                TempData["SaveResult"] = "Your session was created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your session could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateSessionService();
            var detail = service.GetSessionById(id);
            ViewBag.Games = new SelectList(GetGames(), "GameId", "Title");
            var model = new SessionEdit
            {
                SessionId = detail.SessionId,
                GameId = detail.GameId,
                Date = detail.Date,
                Players = detail.Players, 
                Notes = detail.Notes
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, SessionEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.SessionId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateSessionService();

            if (service.UpdateSession(model))
            {
                TempData["SaveResult"] = "Your session information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Your session information could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateSessionService();
            var model = svc.GetSessionById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateSessionService();

            service.DeleteSession(id);

            TempData["SaveResult"] = "Your session was deleted.";

            return RedirectToAction("Index");
        }

        private SessionService CreateSessionService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new SessionService(userId);
            return service;
        }

        private List<GameListItem> GetGames()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            var games = service.GetGames().OrderBy(g => g.Title).ToList();

            return games;
        }
    }
}