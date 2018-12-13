using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class IdleController : Controller
    {
        // GET: Idle
        public ActionResult Index()
        {
            return View(IdleRepo.All());
        }
        public ActionResult List()
        {
            return PartialView("_List", IdleRepo.All());
        }
        public ActionResult search(string key)
        {
            List<IdleViewModel> result = IdleRepo.search(key);
            return PartialView("_ListIdle", result);
        }
        public ActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(CategoryRepo.All(), "id", "code");
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(IdleViewModel model)
        {
            ResponResultViewModel result = IdleRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(long id)
        {
            ViewBag.CategoryList = new SelectList(CategoryRepo.All(), "id", "code");
            return PartialView("_Edit", IdleRepo.GetId(id));
        }
        [HttpPost]
        public ActionResult Edit(IdleViewModel model)
        {
            ResponResultViewModel result = IdleRepo.Update(model);
            return Json(new {success = result.Success, message =result.Message, entity =result.Entity }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Delete(long id)
        {
            return PartialView("_Delete", IdleRepo.GetId(id));
        }
        [HttpPost]
        public ActionResult Delete(IdleViewModel model)
        {
            ResponResultViewModel result = IdleRepo.isdelete(model);
            return Json(new { success = result.Success, message = result.Message, entity = result.Entity }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult ispublish(long id)
        {
            return PartialView("publish", IdleRepo.GetId(id));
        }
        [HttpPost]
        public ActionResult ispublish(IdleViewModel model)
        {
            ResponResultViewModel result = IdleRepo.ispublish(model);
            return Json(new { success = result.Success, message = result.Message, entity = result.Entity }, JsonRequestBehavior.AllowGet);
        }
    }
}