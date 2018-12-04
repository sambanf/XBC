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
        public ActionResult Index()
        {
            return View(RoleRepo.All());
        }
        // List
        public ActionResult List()
        {
            return PartialView("_List", RoleRepo.All());
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
        public ActionResult Edit()
        {
            return PartialView("_Edit");
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
    }
}