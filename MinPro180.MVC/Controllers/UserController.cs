using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinPro180.Repository;
using MinPro180.ViewModel;

namespace MinPro180.MVC.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(string search)
        {
            return View(UserRepo.All(search));
        }
        // List
        public ActionResult List(string search)
        {
            return PartialView("_List", UserRepo.All(search));
        }
        //Create
        public ActionResult Create()
        {
            ViewBag.ListRole = new SelectList(RoleRepo.All(), "id", "name");//untuk dropdownlist
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            ViewBag.ListRole = new SelectList(RoleRepo.All(), "id", "name");//untuk dropdownlist
            ResponResultViewModel result = UserRepo.Update(model);
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
            ViewBag.ListRole = new SelectList(RoleRepo.All(), "id", "name");//untuk dropdownlist
            return PartialView("_Edit", UserRepo.GetUser(id));
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            ViewBag.ListRole = new SelectList(RoleRepo.All(), "id", "name");//untuk dropdownlist
            ResponResultViewModel result = UserRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Deactive(int id)
        {
            return PartialView("_Deactive", UserRepo.GetUser(id));
        }
        [HttpPost]
        public ActionResult Deactive(UserViewModel model)
        {
            ResponResultViewModel result = UserRepo.Deactive(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}