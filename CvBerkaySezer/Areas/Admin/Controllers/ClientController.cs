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
			var domains = domainRepo.List(x => x.ClientId == Id && x.IsDeleted == false);

			ViewBag.HostingCount = hostings.Where(x => x.IsActive).Count();
			ViewBag.DomainCount = domains.Where(x => x.IsActive).Count();

			ClientViewModel clientView = new ClientViewModel()
			{
				Hostings = hostings,
				Client = client,
				Domains = domains
			};

			return View(clientView);
		}

		DomainRepository domainRepo = new DomainRepository();

		#region Domain
		[HttpGet]
		public ActionResult EditDomain(int Id)
		{
			ViewBag.Id = Id;
			ViewBag.ServiceProviders = Functions.DropdownListItems.GetServiceProvider();
			var d = domainRepo.Find(x => x.Id == Id);
			return View(d);
		}

		[HttpPost]
		public ActionResult EditDomain(Domain d)
		{
			var domain = domainRepo.Find(x => x.Id == d.Id);
			d.ClientId = domain.ClientId;

			if (!ModelState.IsValid)
			{
				string errors = "";

				foreach (ModelState modelState in ViewData.ModelState.Values)
				{
					foreach (ModelError error in modelState.Errors)
					{
						errors += $"{error.ErrorMessage} - ";
					}
				}

				TempData["DomainEditMessage"] = "Domain bilgisi düzenlenirken bir hata ile karşılaşıldı";
				TempData["DomainEditType"] = "error";

				ViewBag.Id = domain.Id;
				ViewBag.ServiceProviders = Functions.DropdownListItems.GetServiceProvider();
				return View(domain);
			}
			else
			{
				domain.Description = d.Description;
				domain.ServiceProviderId = d.ServiceProviderId;
				domain.Title = d.Title;
				domain.DomainName = d.DomainName;
				domain.RegistrationDate = d.RegistrationDate;
				domain.NextPaymentDate = d.NextPaymentDate;
				domain.NameServer1 = d.NameServer1;
				domain.NameServer2 = d.NameServer2;
				domain.Amount = d.Amount;
				domainRepo.Update();

				TempData["DomainMessage"] = "Domain bilgisi başarıyla düzenlendi";
				TempData["DomainType"] = "success";

				return RedirectToAction("Detail", "Client", new { Id = domain.ClientId });
			}
		}

		[HttpGet]
		public ActionResult AddDomain(int Id)
		{
			ViewBag.ClientId = Id;
			ViewBag.ServiceProviders = Functions.DropdownListItems.GetServiceProvider();
			return View();
		}

		[HttpPost]
		public ActionResult AddDomain(Domain d, int Id)
		{
			if (!ModelState.IsValid)
			{
				ViewBag.ClientId = Id;
				ViewBag.ServiceProviders = Functions.DropdownListItems.GetServiceProvider();

				TempData["DomaingMessage"] = "Domain bilgisi eklenirken bir hata ile karşılaşıldı";
				TempData["DomainType"] = "error";

				return View();
			}
			else
			{
				domainRepo.Add(d);

				TempData["DomaingMessage"] = "Domain bilgisi başarıyla eklendi";
				TempData["DomaingType"] = "success";

				return RedirectToAction("Detail", "Client", new { Id = Id });
			}
		}
		#endregion

		#region Hosting
		[HttpGet]
		public ActionResult EditHosting(int Id)
		{
			ViewBag.Id = Id;
			ViewBag.ServiceProviders = Functions.DropdownListItems.GetServiceProvider();
			var h = hosting.Find(x => x.Id == Id);
			return View(h);
		}

		[HttpPost]
		public ActionResult EditHosting(Hosting h)
		{
			var host = hosting.Find(x => x.Id == h.Id);
			h.ClientId = host.ClientId;

			if (!ModelState.IsValid)
			{
				string errors = "";

				foreach (ModelState modelState in ViewData.ModelState.Values)
				{
					foreach (ModelError error in modelState.Errors)
					{
						errors += $"{error.ErrorMessage} - ";
					}
				}

				TempData["HostingEditMessage"] = "Hosting bilgisi düzenlenirken bir hata ile karşılaşıldı";
				TempData["HostingEditType"] = "error";

				ViewBag.Id = host.Id;
				ViewBag.ServiceProviders = Functions.DropdownListItems.GetServiceProvider();
				return View(host);
			}
			else
			{
				host.Description = h.Description;
				host.ServiceProviderId = h.ServiceProviderId;
				host.Title = h.Title;
				host.UserName = h.UserName;
				host.RegistrationDate = h.RegistrationDate;
				host.NextPaymentDate = h.NextPaymentDate;
				host.HostUrl = h.HostUrl;
				host.Amount = h.Amount;
				hosting.Update();

				TempData["HostingMessage"] = "Hosting bilgisi başarıyla düzenlendi";
				TempData["HostingType"] = "success";

				return RedirectToAction("Detail", "Client", new { Id = host.ClientId });
			}
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
		#endregion
	}
}