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
    public class ServiceController : Controller
    {
        ServiceRepository db = new ServiceRepository();
        // GET: Admin/Service
        public ActionResult Index()
        {
            var services = db.List();
            return View(services);
        }

        [HttpPost]
        public ActionResult Edit(Service s)
        {
            var service = db.Find(x => x.Id == s.Id);

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string image = SaveImage.SaveContentImage(Request, Server, s.Title.Replace(" ", ""));
                    if (!string.IsNullOrEmpty(image)) service.ImageUrl = image;
                }

                service.IsDeleted = s.IsDeleted;
                service.Title = s.Title.Trim();
                service.Definition = s.Definition.Trim();
                db.Update();

                TempData["ServiceMessage"] = "Hizmet başarıyla düzenlendi";
                TempData["ServiceType"] = "success";
            }
            else
            {
                TempData["ServiceMessage"] = "Hizmet düzenlenirken bir hata ile karşılaşıldı";
                TempData["ServiceType"] = "error";
            }


            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(AddServiceViewModel s)
        {
            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string image = SaveImage.SaveContentImage(Request, Server, s.AddTitle.Replace(" ", ""));
                    if (!string.IsNullOrEmpty(image)) s.AddImageUrl = image;
                }

                Service service = new Service
                {
                    Definition = s.AddDefinition.Trim(),
                    Title = s.AddTitle.Trim(),
                    ImageUrl = s.AddImageUrl
                };

                db.Add(service);

                TempData["ServiceMessage"] = "Hizmet başarıyla eklendi";
                TempData["ServiceType"] = "success";
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

                TempData["ServiceMessage"] = "Hizmet düzenlenirken bir hata ile karşılaşıldı";
                TempData["ServiceType"] = "error";
            }

            return RedirectToAction("Index");
        }
    }
}