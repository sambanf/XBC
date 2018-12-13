using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class AssignmentController : Controller
    {
		// GET: Assignment
		public ActionResult Index()
		{

			return View(AssignmentRepo.All(""));
		}

		public ActionResult List(string search)
		{
			return PartialView("_List", AssignmentRepo.All(search));
		}
		public ActionResult Create()
		{
			ViewBag.Biodatalist = new SelectList(BiodataRepo.All(""), "id", "name");
			return PartialView("_Create");
		}
		[HttpPost]
		public ActionResult Create(AssignmentViewModel model)
		{
			ResponResultViewModel result = AssignmentRepo.Update(model);
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
			return PartialView("_Edit",AssignmentRepo.GetAssignment(id));
		}
		[HttpPost]
		public ActionResult Edit(AssignmentViewModel model)
		{
			ResponResultViewModel result = AssignmentRepo.Update(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
		public ActionResult MarkAsDone(int id)
		{
			return PartialView("_MarkAsDone", AssignmentRepo.GetAssignment(id));
		}

		[HttpPost]
		public ActionResult MarkAsDone(AssignmentViewModel model)
		{
			ResponResultViewModel result = AssignmentRepo.CreateDone(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Hold(int id)
		{
			return PartialView("_Hold", AssignmentRepo.GetAssignment(id));
		}

		[HttpPost]
		public ActionResult Hold(AssignmentViewModel model)
		{
			ResponResultViewModel result = AssignmentRepo.CreateHold(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
		public ActionResult Delete(int id)
		{
			
			return PartialView("_IsDelete",AssignmentRepo.GetAssignment(id));
		}
		[HttpPost]
		public ActionResult Delete(AssignmentViewModel model)
		{
			ResponResultViewModel result = AssignmentRepo.is_delete(model);
			return Json(new
			{
				success = result.Success,
				message = result.Message,
				entity = result.Entity
			}, JsonRequestBehavior.AllowGet);
		}
	}
}