using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace CvBerkaySezer.Areas.Admin.Functions
{
    public static class SaveImage
    {
        public static string SaveContentImage(HttpRequestBase Request, HttpServerUtilityBase Server, string dosyaAdi)
        {
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            if (string.IsNullOrEmpty(uzanti)) return "";

            string dosyaYolu = $"/Content/Images/{dosyaAdi.Replace("/", "").Replace("-", "")}{uzanti}";
            Request.Files[0].SaveAs(Server.MapPath(dosyaYolu));

            return dosyaYolu;
        }

        public static string SaveProjectImage(HttpRequestBase Request, HttpServerUtilityBase Server, string dosyaAdi)
        {
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            if (string.IsNullOrEmpty(uzanti)) return "";

            string dosyaYolu = $"/Content/images/Project/{dosyaAdi.Replace("/","").Replace("-","")}{uzanti}";
            Request.Files[0].SaveAs(Server.MapPath(dosyaYolu));

            return dosyaYolu;
        }

        public static string SaveServiceImage(HttpRequestBase Request, HttpServerUtilityBase Server, string dosyaAdi)
        {
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            if (string.IsNullOrEmpty(uzanti)) return "";

            string dosyaYolu = $"/Content/images/Service/{dosyaAdi.Replace("/", "").Replace("-", "")}{uzanti}";
            Request.Files[0].SaveAs(Server.MapPath(dosyaYolu));

            return dosyaYolu;
        }

        public static string SaveSkillImage(HttpRequestBase Request, HttpServerUtilityBase Server, string dosyaAdi)
        {
            string uzanti = Path.GetExtension(Request.Files[0].FileName);
            if (string.IsNullOrEmpty(uzanti)) return "";

            string dosyaYolu = $"/Content/images/Skill/{dosyaAdi.Replace("/", "").Replace("-", "")}{uzanti}";
            Request.Files[0].SaveAs(Server.MapPath(dosyaYolu));

            return dosyaYolu;
        }
    }
}