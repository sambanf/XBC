using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class TestimonyController : Controller
    {
        // GET: Testimony
        public ActionResult Index(string search)
        {
            return View(TestimonyRepo.All(search));
        }

        public ActionResult List(string search)
        {
            return PartialView("_List", TestimonyRepo.All(search));
        }
        public ActionResult Create()
        {
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(TestimonyViewModel model)
        {
            ResponResultViewModel result = TestimonyRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Edit(long id)
        {
            return PartialView("_Edit", TestimonyRepo.GetTestimony(id));
        }
        [HttpPost]
        public ActionResult Edit(TestimonyViewModel model)
        {
            ResponResultViewModel result = TestimonyRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Delete(long id)
        {
            return PartialView("_Delete", TestimonyRepo.GetTestimony(id));
        }
        [HttpPost]
        public ActionResult Delete(TestimonyViewModel model)
        {
            ResponResultViewModel result = TestimonyRepo.Update2(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}