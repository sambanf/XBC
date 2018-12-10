﻿using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class VersionController : Controller
    {
        // GET: Version
        public ActionResult Index()
        {
            return View(VersionRepo.All());
        }

        public ActionResult Create()
        {
            return PartialView("_Create", VersionRepo.GetLastVersion());
        }

        [HttpPost]
        public ActionResult Create(VersionViewModel model)
        {
            ResponResultViewModel result = VersionRepo.Create(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete()
        {
            return PartialView("_Delete", VersionRepo.GetCurrentVersion());
        }

        [HttpPost]
        public ActionResult Delete(VersionViewModel model)
        {
            ResponResultViewModel result = VersionRepo.Delete(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            return PartialView("_Detail", VersionRepo.Detail());
        }

        public ActionResult Detailitem(int id)
        {
            return PartialView("_Detailitem", VersionRepo.Detailitem(id));
        }

        public ActionResult Question()
        {
            ViewBag.Questionlist = new SelectList(QuestionRepo.All(null), "id", "question");
            return PartialView("_Question");
        }
    }
}