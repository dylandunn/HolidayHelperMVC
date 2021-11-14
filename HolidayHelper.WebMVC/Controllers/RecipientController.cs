using HolidayHelper.Models.RecipientModels;
using HolidayHelper.Services.RecipientServices;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HolidayHelper.WebMVC.Controllers
{
    [Authorize]
    public class RecipientController : Controller
    {
        // GET: Recipient
        public ActionResult Index()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipientService(userId);
            var model = service.GetRecipients();

            return View(model);
        }
        
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(RecipientCreate model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var service = CreateRecipientService();

            if(service.CreateRecipient(model))
            {
                TempData["SaveResult"] = "Recipient was created!";
                return RedirectToAction("Index");
            };
            ModelState.AddModelError("", "Recipient could not be created");
            return View(model);
           
        }

        public ActionResult Details(int id)
        {
            var svc = CreateRecipientService();
            var model = svc.GetRecipientById(id);

            return View(model);
        }
        
        public ActionResult Edit(int id)
        {
            var service = CreateRecipientService();
            var detail = service.GetRecipientById(id);
            var model =
                new RecipientEdit
                {
                    Name = detail.Name,
                    Relation = detail.Relation,
                    Interests = detail.Interests,
                    Avoid = detail.Avoid,
                    BirthDay = detail.BirthDay
                };
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, RecipientEdit model)
        {
            if (!ModelState.IsValid) return View(model);

            if(model.RecipientId != id)
            {
                ModelState.AddModelError("", "Id Mismatch");
                return View(model);
            }

            var service = CreateRecipientService();

            if (service.UpdateRecipient(model))
            {
                TempData["Save Result"] = "Recipient was updated";
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Recipient could not be updated");
            return View(model);
        }

        [ActionName("Delete")]
        public ActionResult Delete(int id)
        {
            var svc = CreateRecipientService();
            var model = svc.GetRecipientById(id);

            return View(model);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeletePost(int id)
        {
            var service = CreateRecipientService();
            service.DeleteRecipient(id);

            TempData["Save Result"] = "Recipent Has Been Deleted";

            return RedirectToAction("Index");
        } 
        private RecipientService CreateRecipientService()
        {
            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipientService(userId);
            return service;
        }
    }
}