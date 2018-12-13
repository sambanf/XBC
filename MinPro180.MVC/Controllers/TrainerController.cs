using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class TrainerController : Controller
    {
        // GET: Trainer
        public ActionResult Index(string search)
        {
            return View(TrainerRepo.All(search));
        }

        public ActionResult List(string search)
        {
            return PartialView("_List", TrainerRepo.All(search));
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(TrainerViewModel model)
        {
            ResponResultViewModel result = TrainerRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(long id)
        {
            return PartialView("_Edit", TrainerRepo.GetTrainer(id));
        }
        [HttpPost]
        public ActionResult Edit(TrainerViewModel model)
        {
            ResponResultViewModel result = TrainerRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(long id)
        {
            return PartialView("_Delete", TrainerRepo.GetTrainer(id));
        }
        [HttpPost]
        public ActionResult Delete(TrainerViewModel model)
        {
            ResponResultViewModel result = TrainerRepo.Update2(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}