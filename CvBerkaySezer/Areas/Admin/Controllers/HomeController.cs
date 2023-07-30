using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            ServiceRepository service = new ServiceRepository();
            ViewBag.Service = service.List(x => x.IsDeleted == false).Count;

            SkillRepository skill = new SkillRepository();
            ViewBag.Skill = skill.List(x => x.IsDeleted == false).Count;

            ProjectRepository project = new ProjectRepository();
            ViewBag.Project = project.List(x => x.IsDeleted == false).Count;

            ContactRepository message = new ContactRepository();
            ViewBag.Message = message.List(x => x.IsDelete == false && x.IsRead == false).Count;

            return View();
        }
    }
}