﻿using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;

namespace MinPro180.MVC.Controllers
{
    [Authorize]
    public class QuestionController : Controller
    {
        // GET: Question
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult List(string search)
        {
            
            return PartialView("_List", QuestionRepo.All(search));
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(QuestionViewModel model)
        {
            var userid =  (long)Session["userid"];
            ResponResultViewModel result = QuestionRepo.Update(model, userid);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Delete(int id)
        {
            return PartialView("_Delete", QuestionRepo.GetQuestion(id));
        }

        [HttpPost]
        public ActionResult Delete(QuestionViewModel model)
        {
            var userid = (long)Session["userid"];
            ResponResultViewModel result = QuestionRepo.Update(model, userid);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

    }

}