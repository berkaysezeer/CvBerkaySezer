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
            return PartialView();
        }

        public PartialViewResult PartialProject()
        {
            return PartialView();
        }

        public PartialViewResult PartialContent()
        {
            return PartialView();
        }

        public PartialViewResult PartialServices()
        {
            return PartialView();
        }

        public PartialViewResult PartialSkills()
        {
            return PartialView();
        }

        public PartialViewResult PartialContact()
        {
            return PartialView();
        }
    }
}