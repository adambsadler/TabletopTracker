using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TabletopTracker.Models.Publisher;
using TabletopTracker.Services;

namespace TabletopTracker.WebMVC.Controllers
{
    [Authorize]
    public class PublisherController : Controller
    {
        // GET: Publisher
        public ActionResult Index()
        {
            var service = CreatePublisherService();
            var model = service.GetPublishers();
            return View(model);
        }

        // GET: Create
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PublisherCreate model)
        {
            if (!ModelState.IsValid) return View(model);

            var service = CreatePublisherService();

            if (service.CreatePublisher(model))
            {
                TempData["SaveResult"] = "The publisher was created successfully.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Publisher could not be created.");

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreatePublisherService();
            var model = svc.GetPublisherById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreatePublisherService();
            var detail = service.GetPublisherById(id);
            var model = new PublisherEdit
            {
                PublisherId = detail.PublisherId,
                Name = detail.Name,
                Website = detail.Website
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, PublisherEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.PublisherId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreatePublisherService();

            if (service.UpdatePublisher(model))
            {
                TempData["SaveResult"] = "Publisher information was updated.";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Publisher information could not be updated.");
            return View();
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreatePublisherService();
            var model = svc.GetPublisherById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreatePublisherService();

            service.DeletePublisher(id);

            TempData["SaveResult"] = "This publisher was deleted.";

            return RedirectToAction("Index");
        }

        private PublisherService CreatePublisherService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new PublisherService(userId);
            return service;
        }
    }
}