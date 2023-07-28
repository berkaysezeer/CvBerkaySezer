using CvBerkaySezer.Areas.Admin.Functions;
using CvBerkaySezer.Models;
using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static CvBerkaySezer.Areas.Admin.ViewModels.SkillViewModel;

namespace CvBerkaySezer.Areas.Admin.Controllers
{
    public class SkillController : Controller
    {
        SkillRepository db = new SkillRepository();
        // GET: Admin/Service
        public ActionResult Index()
        {
            var skills = db.List();
            return View(skills);
        }

        [HttpPost]
        public ActionResult Edit(Skill s)
        {
            var service = db.Find(x => x.Id == s.Id);

            if (ModelState.IsValid)
            {
                service.IsDeleted = s.IsDeleted;
                service.Title = s.Title.Trim();
                service.Rate = s.Rate;
                db.Update();

                TempData["SkillMessage"] = "Yetenek başarıyla düzenlendi";
                TempData["SkillType"] = "success";
            }
            else
            {
                TempData["SkillMessage"] = "Yetenek düzenlenirken bir hata ile karşılaşıldı";
                TempData["SkillType"] = "error";
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(AddServiceModel s)
        {
            if (ModelState.IsValid)
            {
                Skill skill = new Skill
                {
                    Title = s.AddTitle,
                    Rate = s.AddRate
                };

                db.Add(skill);

                TempData["SkillMessage"] = "Yetenek başarıyla eklendi";
                TempData["SkillType"] = "success";
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

                TempData["ServiceMessage"] = "Yetenek düzenlenirken bir hata ile karşılaşıldı";
                TempData["ServiceType"] = "error";
            }

            return RedirectToAction("Index");
        }
    }
}