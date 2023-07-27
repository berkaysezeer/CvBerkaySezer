using CvBerkaySezer.Models;
using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Areas.Admin.Controllers
{
    public class TitleController : Controller
    {
        TitleRepository db = new TitleRepository();
        // GET: Admin/Title
        public ActionResult Index()
        {
            var title = db.List(x => x.IsDeleted == false).FirstOrDefault();
            return View(title);
        }

        [HttpPost]
        public ActionResult Index(Title t)
        {
            var title = db.Find(x=>x.Id == t.Id);

            if (ModelState.IsValid)
            {
                title.IsDeleted = t.IsDeleted;
                title.Head = t.Head;
                title.Content = t.Content;
                db.Update();
            }

            return View(title);
        }
    }
}