using HolidayHelper.Data;
using HolidayHelper.Models.GiftReminderModels;
using HolidayHelper.Services.RecipientServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HolidayHelper.WebMVC.Controllers
{
    public class GiftReminderController : Controller
    {
        private ApplicationDbContext _db = new ApplicationDbContext();
        // GET: GiftReminder
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Create(CreateGiftReminder model)
        {
            if(ModelState.IsValid)
            {
                var giftReminder = new GiftReminder();
               // giftReminder.GiftIdea = new List<GiftIdea>();
                var recipient = _db.Recipients.Find(model.RecipientId);
                if(recipient != null)
                {
                    giftReminder.RecipientId = recipient.RecipientId;
                }
                else
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                foreach(int giftIdeaId in model.GiftIdeaIds)
                {
                    var giftIdea = _db.GiftIdeas.Find(giftIdeaId);
                    if(giftIdea != null)
                    {
                        giftReminder.GiftIdea.Add(giftIdea);
                    }
                    else
                    {
                        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                    }
                }
                _db.GiftReminders.Add(giftReminder);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            // Add view models
            return View(model);
        }
    }
}