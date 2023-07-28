using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Areas.Admin.Controllers
{
    public class NavbarMessageController : Controller
    {
        ContactRepository db = new ContactRepository();
        // GET: Admin/NavbarMessage
        public ActionResult Index()
        {
            var unreadMessage = db.List(x => x.IsRead == false);
            ViewBag.MessageCount = unreadMessage.Count;
            var message = unreadMessage.OrderByDescending(x => x.Time).Take(5).ToList();
            return PartialView(message);
        }
    }
}