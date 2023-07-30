using CvBerkaySezer.Areas.Admin.Functions;
using CvBerkaySezer.Areas.Admin.ViewModels;
using CvBerkaySezer.Models;
using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Areas.Admin.Controllers
{
    public class ProjectController : Controller
    {

        ProjectRepository db = new ProjectRepository();
        public ActionResult Index()
        {
            var projects = db.List();
            return View(projects);
        }

        [HttpPost]
        public ActionResult Edit(Project p)
        {
            var project = db.Find(x => x.Id == p.Id);

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string image = SaveImage.SaveProjectImage(Request, Server, p.Title.Replace(" ", ""));
                    if (!string.IsNullOrEmpty(image)) project.ImageUrl = image;
                }

                project.IsDeleted = p.IsDeleted;
                project.ProjectUrl = p.ProjectUrl;
                project.Title = p.Title.Trim();
                project.Tag = p.Tag.Trim();
                db.Update();

                TempData["ProjectMessage"] = "Proje başarıyla düzenlendi";
                TempData["ProjectType"] = "success";
            }
            else
            {
                TempData["ProjectMessage"] = "Proje düzenlenirken bir hata ile karşılaşıldı";
                TempData["ProjectType"] = "error";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(AddProjectViewModel p)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string image = SaveImage.SaveProjectImage(Request, Server, p.AddTitle.Replace(" ", ""));
                    if (!string.IsNullOrEmpty(image)) p.AddImageUrl = image;
                }

                Project project = new Project
                {
                    Tag = p.AddTag,
                    Title = p.AddTitle,
                    ImageUrl = p.AddImageUrl,
                    ProjectUrl = p.AddProjectUrl
                };

                db.Add(project);

                TempData["ProjectMessage"] = "Proje başarıyla eklendi";
                TempData["ProjectType"] = "success";
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

                TempData["ProjectMessage"] = "Proje düzenlenirken bir hata ile karşılaşıldı";
                TempData["ProjectType"] = "error";
            }

            return RedirectToAction("Index");
        }
    }
}