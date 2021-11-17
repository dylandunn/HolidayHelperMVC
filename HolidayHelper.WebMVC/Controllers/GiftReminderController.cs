using HolidayHelper.Data;
using HolidayHelper.Models.GiftReminderModels;
using HolidayHelper.Services.GiftReminderServices;
using HolidayHelper.Services.RecipientServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Mvc;

namespace HolidayHelper.WebMVC.Controllers
{
    [Authorize]
    public class GiftReminderController : Controller
    {
        
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: GiftReminder
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GiftReminderService(userId);
            var model = service.GetGiftReminders();
            return View(model);
        }
        public ActionResult Create()
        {
            ViewBag.RecipientId = new SelectList(_db.Recipients, "RecipientId", "Name");
            ViewBag.GiftIdeas = new SelectList(_db.GiftIdeas, "GiftIdeaId", "Product");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateGiftReminder model)
        {
            var svc = CreateGiftReminderService();
            if (svc.CreateGiftReminder(model))
            {
                var giftReminder = new GiftReminder();
                giftReminder.GiftIdeas = new List<GiftIdea>();

                var recipient = _db.Recipients.Find(model.RecipientId);
                //var recipient = service.GetRecipientById(model.RecipientId);
                if (recipient != null)
                {
                    giftReminder.RecipientId = recipient.RecipientId;
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                foreach (int giftIdeaId in model.GiftIdeaIds)
                {
                    var giftIdea = _db.GiftIdeas.Find(giftIdeaId);
                    if (giftIdea != null)
                    {

                        giftReminder.GiftIdeas.Add(giftIdea);

                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                TempData["SaveResult"] = "Reminder was created";

                return RedirectToAction("Index");
            }
            ModelState.AddModelError("", "Reminder was not created");
            return View(model);

            
            ViewBag.RecipientId = new SelectList(_db.Recipients, "RecipientId", "Name", model.RecipientId);
            ViewBag.GiftIdeas = new SelectList(_db.GiftIdeas, "GiftIdeaId", "Product", model.GiftIdeaIds);

            return View(model);
        }

        public ActionResult Details(int id)
        {
            var svc = CreateGiftReminderService();
            var model = svc.GetGiftReminderById(id);

            return View(model);
        }



        public ActionResult Edit(int id)
        {
            var service = CreateGiftReminderService();
            var detail = service.GetGiftReminderById(id);
            var model =
                new GiftReminderEdit
                {
                    GiftReminderId = detail.GiftReminderId,
                    GiftNeededBy = detail.GiftNeededBy,
                    Occasion = detail.Occasion,
                };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, GiftReminderEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if (model.GiftReminderId != id)
            {
                ModelState.AddModelError("", "ID mismatch");
                return View(model);
            }

            var service = CreateGiftReminderService();

            if (service.UpdateGiftReminder(model))
            {
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Gift Reminder Could Not Be Updated");
            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateGiftReminderService();

            service.DeleteGiftReminder(id);

            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var svc = CreateGiftReminderService();
            var model = svc.GetGiftReminderById(id);

            return View(model);
        }


        public GiftReminderService CreateGiftReminderService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new GiftReminderService(userId);
            return service;
        }
    }

}