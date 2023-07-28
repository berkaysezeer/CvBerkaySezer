using CvBerkaySezer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace CvBerkaySezer.Areas.Admin.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        // GET: Admin/Login
        public ActionResult Index()
        {
            return View();
        }

        Context db = new Context();

        [HttpPost]
        public ActionResult Index(User user)
        {
            string encPassword = Functions.DataSecurity.Encrypt(user.Password);

            if (db.Users.FirstOrDefault(x => x.UserName == user.UserName && x.Password == encPassword) != null)
            {
                FormsAuthentication.SetAuthCookie(user.UserName, false);
                Session["UserName"] = user.UserName;
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        public ActionResult Out()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return RedirectToAction("Index");
        }
    }
}