using CvBerkaySezer.Areas.Admin.Functions;
using CvBerkaySezer.Models;
using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Areas.Admin.Controllers
{
    public class ContentController : Controller
    {
        ContentRepository db = new ContentRepository();
        // GET: Admin/Content
        public ActionResult Index()
        {
            var content = db.List().FirstOrDefault();
            return View(content);
        }

        [HttpPost]
        public ActionResult Index(Content c)
        {
            var content = db.Find(x => x.Id == c.Id);

            if (ModelState.IsValid)
            {
                if (Request.Files.Count > 0)
                {
                    string image = SaveImage.SaveContentImage(Request, Server, "berkaysezer");
                    if (!string.IsNullOrEmpty(image)) content.ImageUrl = image;
                }

                content.Title = c.Title.Trim();
                content.Fullname = c.Fullname.Trim();
                content.ContentParagrap = c.ContentParagrap.Trim();
                db.Update();

                TempData["Message"] = "İçerik başarıyla güncellendi";
                TempData["Type"] = "success";
            }

            return View(content);
        }
    }
}