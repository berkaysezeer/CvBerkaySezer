using CvBerkaySezer.Models;
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
        public ActionResult Index(string f)
        {
            ViewBag.MessageCount = db.List(x => x.IsRead == false && x.IsDelete == false);

            List<Contact> messages = new List<Contact>();

            if (string.IsNullOrEmpty(f) || f == "okunmamislar") messages = db.List(x => x.IsRead == false && x.IsDelete == false);
            else if (f == "okunanlar") messages = db.List(x => x.IsRead && x.IsDelete == false);
            else if (f == "copkutusu") messages = db.List(x => x.IsDelete);

            return View(messages);
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

        public ActionResult MessageMenu()
        {
            ViewBag.OkunmamisSayisi = db.List(x => x.IsRead == false && x.IsDelete == false).Count;
            ViewBag.OkunmusSayisi = db.List(x => x.IsRead && x.IsDelete == false).Count;
            ViewBag.SilinenMesajSayisi = db.List(x => x.IsDelete).Count;

            return PartialView();
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var message = db.Find(x => x.Id == Id);
            try
            {
                message.IsDelete = true;
                db.Update();

                TempData["ContactMessage"] = "Mesaj başarıyla silindi";
                TempData["ContactType"] = "success";
            }
            catch (Exception)
            {
                TempData["ContactMessage"] = "Mesaj silinirken bir hata ile karşılaşıldı";
                TempData["ContactType"] = "error";

            }

            return RedirectToAction("Index", "Message");
        }

        public ActionResult NextMessage(int Id)
        {
            Contact nextMessage;
            List<Contact> message = db.List(x => x.Id > Id);
            int nextId = 0;

            if (message.Count == 0) return RedirectToAction("Detail", "Message", new { Id = Id });
            else
            {
                int counter = Id;

                for (int i = 0; i < message.Count; i++)
                {
                    counter++;
                    nextMessage = db.Find(x => x.Id == counter);

                    if (nextMessage != null)
                    {
                        nextId = nextMessage.Id;
                        break;
                    }
                }
            }

            return RedirectToAction("Detail", "Message", new { Id = nextId });
        }

        public ActionResult PreviousMessage(int Id)
        {
            Contact previousMessage;
            List<Contact> message = db.List(x => x.Id < Id);
            int previousId = 0;

            if (message.Count == 0) return RedirectToAction("Detail", "Message", new { Id = Id });
            else
            {
                int counter = Id;

                for (int i = 0; i < message.Count; i++)
                {
                    counter--;
                    previousMessage = db.Find(x => x.Id == counter);

                    if (previousMessage != null)
                    {
                        previousId = previousMessage.Id;
                        break;
                    }
                }
            }

            return RedirectToAction("Detail", "Message", new { Id = previousId });
        }
    }
}