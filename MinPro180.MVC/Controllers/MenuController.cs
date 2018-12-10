using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MinPro180.Repository;
using MinPro180.ViewModel;

namespace MinPro180.MVC.Controllers
{
    public class MenuController : Controller
    {
        // GET: Menu
        public ActionResult Index(string search)
        {
            return View(MenuRepo.All(search));
        }
        // List
        public ActionResult List(string search)
        {
            return PartialView("_List", MenuRepo.All(search));
        }
        //Create
        public ActionResult Create()
        {
            ViewBag.ListMenu = new SelectList(MenuRepo.All(null), "id","title");//untuk dropdownlist
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(MenuViewModel model)
        {
            ViewBag.ListMenu = new SelectList(MenuRepo.All(null), "id", "title");//untuk dropdownlist
            ResponResultViewModel result = MenuRepo.Update(model);
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
            ViewBag.ListMenu = new SelectList(MenuRepo.All(null),"id", "title");//untuk dropdownlist
            return PartialView("_Edit", MenuRepo.GetMenu(id));
        }
        [HttpPost]
        public ActionResult Edit(MenuViewModel model)
        {
            ViewBag.ListMenu = new SelectList(MenuRepo.All(null), "id", "title");//untuk dropdownlist
            ResponResultViewModel result = MenuRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Deactive(int id)
        {
            return PartialView("_Deactive", MenuRepo.GetMenu(id));
        }
        [HttpPost]
        public ActionResult Deactive(MenuViewModel model)
        {
            ResponResultViewModel result = MenuRepo.Deactive(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}