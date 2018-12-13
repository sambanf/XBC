using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class TechnologyController : Controller
    {
        // GET: Technology
        public ActionResult Index(string search)
        {
            return View(TechnologyRepo.All(search));
        }

        public ActionResult List(string search)
        {
            return PartialView("_List", TechnologyRepo.All(search));
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(TechnologyViewModel model)
        {
            ResponResultViewModel result = TechnologyRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(long id)
        {
            return PartialView("_Edit", TechnologyRepo.GetTechnology(id));
        }
        [HttpPost]
        public ActionResult Edit(TechnologyViewModel model)
        {
            ResponResultViewModel result = TechnologyRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(long id)
        {
            return PartialView("_Delete", TechnologyRepo.GetTechnology(id));
        }
        [HttpPost]
        public ActionResult Delete(TechnologyViewModel model)
        {
            ResponResultViewModel result = TechnologyRepo.Update2(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Detail()
        {
            return PartialView("_Detail", TechnologyRepo.Detail());
        }

        public ActionResult Detailtrainer(int id)
        {
            return PartialView("_Detailtrainer", TechnologyRepo.Detailtrainer(id));
        }

        public ActionResult Detail2()
        {
            return PartialView("_Detail2", TechnologyRepo.Detail2());
        }
        public ActionResult Trainer()
        {
            ViewBag.Trainerlist = new SelectList(TrainerRepo.All(null), "id", "name");
            return PartialView("_Trainer");
        }

        public ActionResult Trainer2()
        {
            ViewBag.Trainerlist = new SelectList(TrainerRepo.All(null), "id", "name");
            return PartialView("_Trainer2");
        }

    }
}