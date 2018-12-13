using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class MonitoringController : Controller
    {
        // GET: Monitoring
        public ActionResult Index()
		{

			return View();
		}

		public ActionResult List(string search)
		{
			return PartialView("_List", MonitoringRepo.All(search));
		}
		public ActionResult Create()
		{
			ViewBag.Biodatalist = new SelectList(BiodataRepo.All(""), "id", "name");
			return PartialView("_Create");
		}
		[HttpPost]
		public ActionResult Create(MonitoringViewModel model)
		{
			ResponResultViewModel result = MonitoringRepo.Update(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Edit(int id)
		{
			ViewBag.Biodatalist = new SelectList(BiodataRepo.All(""), "id", "name");
			return PartialView("_Edit", MonitoringRepo.GetMonitoring(id));
		}

		[HttpPost]
		public ActionResult Edit(MonitoringViewModel model)
		{
			ResponResultViewModel result = MonitoringRepo.Update(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Placement(int id)
		{
			return PartialView("_Placement", MonitoringRepo.GetPlacement(id));
		}

		[HttpPost]
		public ActionResult Placement(MonitoringViewModel model)
		{
			ResponResultViewModel result = MonitoringRepo.CreatePlacement(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Delete(int id)
		{
			return PartialView("_IsDelete", MonitoringRepo.GetMonitoring(id));
		}

		[HttpPost]
		public ActionResult Delete(MonitoringViewModel model)
		{
			ResponResultViewModel result = MonitoringRepo.Is_Delete(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
	}
}