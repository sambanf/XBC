using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kitchen.ViewModel;
using MinPro180.Repository;
using MinPro180.ViewModel;

namespace MinPro180.MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View(UserRepo.All());
        }
        public ActionResult List()
        {
            return PartialView("_List", UserRepo.All());
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            ResponResultViewModel result = UserRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Edit()
        {
            return PartialView("_Edit");
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            ResponResultViewModel result = UserRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}