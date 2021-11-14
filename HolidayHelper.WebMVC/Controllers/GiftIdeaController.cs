using HolidayHelper.Models.GiftIdeaModels;
using HolidayHelper.Services.GiftIdeaServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayHelper.WebMVC.Controllers
{
    [Authorize]
    public class GiftIdeaController : Controller
    {
        // GET: GiftIdea
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GiftIdeaService(userId);
            var model = service.GetGiftIdeas();
            return View(model);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GiftIdeaCreate model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var service = CreateGiftIdeaService();

            if(service.CreateGiftIdea(model))
            {
                TempData["SaveResult"] = "Gift Idea Has Been Created";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Gift Idea Could Not Be Created");
            return View(model);
        }
        public ActionResult Details(int id)
        {
            var svc = CreateGiftIdeaService();
            var model = svc.GetGiftIdeaById(id);

            return View(model);
        }

        public ActionResult Edit(int id)
        {
            var service = CreateGiftIdeaService();
            var detail = service.GetGiftIdeaById(id);
            var model =
                new GiftIdeaEdit
                {
                    GiftIdeaId = detail.GiftIdeaId,
                    Product = detail.Product,
                    Price = detail.Price,
                    Location = detail.Location,
                    WebsiteLink = detail.WebsiteLink
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GiftIdeaEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.GiftIdeaId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateGiftIdeaService();

            if(service.UpdateGiftIdea(model))
            {
                TempData["SaveResult"] = "Gift Idea Was Updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Gift Idea Could Not Be Updated");
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGiftIdeaService();

            service.DeleteGiftIdea(id);

            TempData["SaveResult"] = "Gift Idea Was Deleted";
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateGiftIdeaService();
            var model = svc.GetGiftIdeaById(id);

            return View(model);
        }

        private GiftIdeaService CreateGiftIdeaService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GiftIdeaService(userId);
            return service;
        }
    }
}