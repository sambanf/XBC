using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
	public class BiodataController : Controller
	{
		// GET: Biodata
		public ActionResult Index()
		{

			return View();
		}

		public ActionResult List(string search)
		{
			return PartialView("_List", BiodataRepo.All(search));
		}
		public ActionResult Create()
		{
			return PartialView("_Create");
		}


		[HttpPost]
		public ActionResult Create(BiodataViewModel model)
		{
			ResponResultViewModel result = BiodataRepo.Update(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Edit(int id)
		{
			return PartialView("_Edit", BiodataRepo.GetBiodata(id));
		}

		[HttpPost]
		public ActionResult Edit(BiodataViewModel model)
		{
			ResponResultViewModel result = BiodataRepo.Update(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Deactivate(int id)
		{
			return PartialView("_Deactivate", BiodataRepo.GetBiodata(id));
		}
		[HttpPost]
		public ActionResult Deactivate(BiodataViewModel model)
		{
			ResponResultViewModel result = BiodataRepo.Update2(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
	}
}
