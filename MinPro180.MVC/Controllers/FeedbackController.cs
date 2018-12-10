using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class FeedbackController : Controller
    {
        // GET: Feedback
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult List()
        {
            return PartialView("_List", FeedbackRepo.All());
        }
        public ActionResult Test()
        {
            ViewBag.Testlist = new SelectList(TestRepo.All(), "id", "name");
            return PartialView("_Test");
        }

        public ActionResult Create(FeedbackViewModel model)
        {
            ResponResultViewModel respon = FeedbackRepo.Save(model);
            return Json(new
            {
                success = respon.Success,
                message = respon.Message,
                entity = respon.Entity
            }, JsonRequestBehavior.AllowGet);
        }

    }
}