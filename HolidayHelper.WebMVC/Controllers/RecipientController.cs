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
        public ActionResult Create(RecipientCreate model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            var userId = Guid.Parse(User.Identity.GetUserId());
            var service = new RecipientService(userId);

            service.CreateRecipient(model);

            return RedirectToAction("Index");
        }
    }
}