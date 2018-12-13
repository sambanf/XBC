using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public ActionResult Index()
        {
            return View(ClassRepo.All());
        }

        public ActionResult List(ClassViewModel entity)
        {
            
            return PartialView("_List", ClassRepo.All());
        }
    }
}