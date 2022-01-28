using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TabletopTracker.Models.Category;
using TabletopTracker.Models.Game;
using TabletopTracker.Models.Publisher;
using TabletopTracker.Services;

namespace TabletopTracker.WebMVC.Controllers
{
    [Authorize]
    public class GameController : Controller
    {
        // GET: Game
        public ActionResult Index()
        {
            var service = CreateGameService();
            var model = service.GetGames();
            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            ViewBag.Publishers = new SelectList(GetPublishers(), "PublisherId", "Name");
            ViewBag.Categories = new SelectList(GetCategories(), "CategoryId", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GameCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreateGameService();

            if (service.CreateGame(model))
            {
                TempData["SaveResult"] = "Your game was added successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Game could not be added.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGameService();
            var model = svc.GetGameById(id);

            return View(model);
        }

        private GameService CreateGameService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GameService(userId);
            return service;
        }

        private List<PublisherListItem> GetPublishers()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PublisherService(userId);
            var publishers = service.GetPublishers().OrderBy(p => p.Name).ToList();

            return publishers;
        }

        private List<CategoryListItem> GetCategories()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new CategoryService(userId);
            var categories = service.GetCategories().OrderBy(c => c.Name).ToList();

            return categories;
        }
    }
}