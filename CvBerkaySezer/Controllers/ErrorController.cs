using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Controllers
{
    [AllowAnonymous]
    public class ErrorController : Controller
    {
        public ActionResult PageError()
        {
            Response.TrySkipIisCustomErrors = true;
            return View();
        }

        public ActionResult Page404()
        {
            Response.StatusCode = 404;
            ViewBag.Message = "Aradığınız Sayfa Bulunamadı";
            Response.TrySkipIisCustomErrors = true;
            return View("Hata");
        }

        public ActionResult Page403()
        {
            Response.StatusCode = 403;
            ViewBag.Message = "Bu Sunucuya Erişim İzniniz Yok";
            Response.TrySkipIisCustomErrors = true;
            return View("Hata");
        }

        public ActionResult Page500()
        {
            Response.StatusCode = 500;
            ViewBag.Message = "Sunucu Kaynaklı Hata";
            Response.TrySkipIisCustomErrors = true;
            return View("Hata");
        }
    }
}