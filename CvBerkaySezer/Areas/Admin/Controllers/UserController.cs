using CvBerkaySezer.Models;
using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Areas.Admin.Controllers
{
    public class UserController : Controller
    {
        UserRepository db = new UserRepository();
        // GET: Admin/User
        public ActionResult Index()
        {
            string username = Session["UserName"].ToString();
            var user = db.Find(x => x.UserName == username);
            user.Password = Functions.DataSecurity.Decrypt(user.Password);

            return View(user);
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            string username = Session["UserName"].ToString();
            var user = db.Find(x => x.UserName == username);

            if (ModelState.IsValid)
            {
                user.FullName = u.FullName;
                user.Password = Functions.DataSecurity.Encrypt(u.Password);
                user.UserName = u.UserName;
                db.Update();

                TempData["UserMessage"] = "Kullanıcı bilgileri başarıyla düzenlendi";
                TempData["UserType"] = "success";
            }
            else
            {
                TempData["UserMessage"] = "Kullanıcı bilgileri düzenlenirken bir hata ile karşılaşıldı";
                TempData["UserType"] = "error";
            }

            user.Password = Functions.DataSecurity.Decrypt(user.Password);
            return View(user);
        }
    }
}