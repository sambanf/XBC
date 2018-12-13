using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView("_List", TestRepo.All());
        }

        public ActionResult Search(string code)
        {
            List<TestViewModel> item = TestRepo.All(code);
            return PartialView("_List", item);
        }

        public ActionResult Create()
        {
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(TestViewModel model)
        {
            ResponResultViewModel result = TestRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int id)
        {
            return PartialView("_Update", TestRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Update(TestViewModel model)
        {
            ResponResultViewModel result = TestRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Deact(int id)
        {
            return PartialView("_Deact", TestRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Deact(TestViewModel model)
        {
            ResponResultViewModel result = TestRepo.Deact(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}