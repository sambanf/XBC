using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class BootcampTypeController : Controller
    {
        // GET: BootcampType
        public ActionResult Index()
        {
            return View(BootcampTypeRepo.All());
        }
        public ActionResult List()
        {
            return PartialView("_List", BootcampTypeRepo.All());
        }
        public ActionResult search(string key)
        {
            List<BootcampTypeViewModel> result = BootcampTypeRepo.search(key);
            return PartialView("_ListBootcampType", result);
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(BootcampTypeViewModel model)
        {
            ResponResultViewModel result = BootcampTypeRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit(long id)
        {
            return PartialView("_Edit", BootcampTypeRepo.GetId(id));
        }
        [HttpPost]
        public ActionResult Edit(BootcampTypeViewModel model)
        {
            ResponResultViewModel result = BootcampTypeRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);

        }
        public ActionResult Delete(long id)
        {
            return PartialView("_Delete", BootcampTypeRepo.GetId(id));
        }
        [HttpPost]
        public ActionResult Delete(BootcampTypeViewModel model)
        {
            ResponResultViewModel result = BootcampTypeRepo.Delete(model.id);
            return Json(new {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}