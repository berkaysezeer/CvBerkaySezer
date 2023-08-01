using CvBerkaySezer.Areas.Admin.ViewModels;
using CvBerkaySezer.Models;
using CvBerkaySezer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CvBerkaySezer.Areas.Admin.Controllers
{
    public class ClientController : Controller
    {
        ClientRepository db = new ClientRepository();
        public ActionResult Index()
        {
            var clients = db.List();
            return View(clients);
        }

        [HttpPost]
        public ActionResult Edit(Client c)
        {
            var client = db.Find(x => x.Id == c.Id);

            if (ModelState.IsValid)
            {
                c.Telephone = c.Telephone.Remove(0, 3).Replace("(", "").Replace(")", "").Replace("-", "");

                if (db.Find(x => x.Telephone == c.Telephone && x.IsDeleted == false) == null || client.Telephone.Equals(c.Telephone))
                {
                    client.Email = c.Email.Trim();
                    client.FullName = c.FullName.Trim();
                    client.IsDeleted = c.IsDeleted;
                    client.Telephone = c.Telephone.Trim();
                    db.Update();

                    TempData["ClientMessage"] = "Müşteri başarıyla düzenlendi";
                    TempData["ClientType"] = "success";
                }
                else
                {
                    TempData["ClientMessage"] = "Girilen telefon numarasına kayıtlı bir müşteri mevcut";
                    TempData["ClientType"] = "error";
                }


            }
            else
            {
                string errors = "";

                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors += $"{error.ErrorMessage} - ";
                    }
                }

                TempData["ClientMessage"] = "Müşteri düzenlenirken bir hata ile karşılaşıldı";
                TempData["ClientType"] = "error";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult Add(AddClientViewModel c)
        {
            c.AddTelephone = c.AddTelephone.Remove(0, 3).Replace("(", "").Replace(")", "").Replace("-", "");

            if (ModelState.IsValid)
            {
                if (db.Find(x => x.Telephone == c.AddTelephone && x.IsDeleted == false) == null)
                {
                    Client client = new Client
                    {
                        Email = c.AddEmail.Trim(),
                        FullName = c.AddFullName.Trim(),
                        Telephone = c.AddTelephone.Trim(),
                        CreatedDate = DateTime.Now,
                    };

                    db.Add(client);

                    TempData["ClientMessage"] = "Müşteri başarıyla eklendi";
                    TempData["ClientType"] = "success";
                }
                else
                {
                    TempData["ClientMessage"] = "Girilen telefon numarasına kayıtlı bir müşteri mevcut";
                    TempData["ClientType"] = "error";
                }
            }
            else
            {
                string errors = "";

                foreach (ModelState modelState in ViewData.ModelState.Values)
                {
                    foreach (ModelError error in modelState.Errors)
                    {
                        errors += $"{error.ErrorMessage} - ";
                    }
                }

                TempData["ClientMessage"] = "Müşteri düzenlenirken bir hata ile karşılaşıldı";
                TempData["ClientType"] = "error";
            }

            return RedirectToAction("Index");
        }

        HostingRepository hosting = new HostingRepository();

        public ActionResult Detail(int Id)
        {
            var client = db.Find(x => x.Id == Id);
            var hostings = hosting.List(x => x.ClientId == Id && x.IsDeleted == false);

            ClientViewModel clientView = new ClientViewModel()
            {
                Hostings = hostings,
                Client = client

            };

            return View(clientView);
        }

        [HttpGet]
        public ActionResult AddHosting(int Id)
        {
            ViewBag.ClientId = Id;
            ViewBag.ServiceProviders = Functions.DropdownListItems.GetServiceProvider();
            return View();
        }

        [HttpPost]
        public ActionResult AddHosting(Hosting h, int Id)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.ClientId = Id;
                ViewBag.ServiceProviders = Functions.DropdownListItems.GetServiceProvider();

                TempData["HostingMessage"] = "Hosting bilgisi eklenirken bir hata ile karşılaşıldı";
                TempData["HostingType"] = "error";

                return View();
            }
            else
            {
                hosting.Add(h);

                TempData["HostingMessage"] = "Hosting bilgisi başarıyla eklendi";
                TempData["HostingType"] = "success";

                return RedirectToAction("Detail", "Client", new { Id = Id });
            }
        }
    }
}