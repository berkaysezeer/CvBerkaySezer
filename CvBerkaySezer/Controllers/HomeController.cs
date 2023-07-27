using CvBerkaySezer.Models;
using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public PartialViewResult PartialTitle()
        {
            TitleRepository db = new TitleRepository();
            var title = db.List(x => x.IsDeleted == false).FirstOrDefault();
            return PartialView(title);
        }

        public PartialViewResult PartialProject()
        {
            ProjectRepository db = new ProjectRepository();
            var projects = db.List(x => x.IsDeleted == false);
            return PartialView(projects);
        }

        public PartialViewResult PartialContent()
        {
            ContentRepository db = new ContentRepository();
            var content = db.List().FirstOrDefault();
            return PartialView(content);
        }

        public PartialViewResult PartialServices()
        {
            ServiceRepository db = new ServiceRepository();
            var services = db.List(x => x.IsDeleted == false);
            return PartialView(services);
        }

        public PartialViewResult PartialSkills()
        {
            SkillRepository db = new SkillRepository();
            var skills = db.List(x => x.IsDeleted == false);
            return PartialView(skills);
        }

        public PartialViewResult PartialContact()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult Contact(Contact contact)
        {
            ContactRepository db = new ContactRepository();
            contact.Time = DateTime.Now;

            if (ModelState.IsValid)
            {
                db.Add(contact);
                TempData["Message"] = "Mesajınız başarıyla gönderildi";
                TempData["Type"] = "success";
            }
            else
            {
                string errors = "";

                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors += $"{error.ErrorMessage} - ";
                    }
                }

                TempData["Message"] = errors;
                TempData["Type"] = "error";
                TempData["Target"] = "";
            }


            return RedirectToAction("Index");
        }
    }
}