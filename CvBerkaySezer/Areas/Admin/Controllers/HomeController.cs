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
            ViewBag.Message = message.List(x => x.IsDeleted == false && x.IsRead == false).Count;

            ClientRepository client = new ClientRepository();
            ViewBag.Client = client.List(x => x.IsDeleted == false).Count;

            HostingRepository hosting = new HostingRepository();
			ViewBag.Hosting = hosting.List(x => x.IsDeleted == false && x.IsActive).Count;

			DomainRepository domain = new DomainRepository();
			ViewBag.Domain = domain.List(x => x.IsDeleted == false && x.IsActive).Count;

			return View();
        }
    }
}