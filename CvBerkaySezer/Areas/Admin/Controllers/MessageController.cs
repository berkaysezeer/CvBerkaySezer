using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Areas.Admin.Controllers
{
    public class MessageController : Controller
    {
        ContactRepository db = new ContactRepository();
        // GET: Admin/Message
        public ActionResult Index()
        {
            var unreadMessage = db.List(x => x.IsRead == false);
            ViewBag.MessageCount = unreadMessage.Count;

            var message = db.List();
            return View(message);
        }

        public ActionResult Detail(int Id)
        {
            var message = db.Find(x => x.Id == Id);
            if (!message.IsRead)
            {
                message.IsRead = true;
                db.Update();
            }

            return View(message);
        }
    }
}