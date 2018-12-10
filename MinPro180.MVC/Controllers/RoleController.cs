using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinPro180.Repository;
using MinPro180.ViewModel;

namespace MinPro180.MVC.Controllers
{
    public class RoleController : Controller
    {
        // GET: Role
        public ActionResult Index(string search)
        {
            return View(RoleRepo.All(search));
        }
        // List
        public ActionResult List(string search)
        {
            return PartialView("_List", RoleRepo.All(search));
        }
        //Create
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(RoleViewModel model)
        {
            ResponResultViewModel result = RoleRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        //Edit
        public ActionResult Edit(int id)
        {
            return PartialView("_Edit",RoleRepo.GetRole(id));
        }
        [HttpPost]
        public ActionResult Edit(RoleViewModel model)
        {
            ResponResultViewModel result = RoleRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Deactive(int id)
        {
            return PartialView("_Deactive", RoleRepo.GetRole(id));
        }
        [HttpPost]
        public ActionResult Deactive(RoleViewModel model)
        {
            ResponResultViewModel result = RoleRepo.Deactive(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}