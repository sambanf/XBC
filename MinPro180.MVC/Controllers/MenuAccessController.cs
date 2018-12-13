using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class MenuAccessController : Controller
    {
        // GET: MenuAccess
        public ActionResult Index()
        {
            ViewBag.RoleList = new SelectList(RoleRepo.All(null), "id", "name");
            return View(MenuAccessRepo.All());
        }
        public ActionResult List()
        {
            return PartialView("_List", MenuAccessRepo.All());
        }
        public ActionResult search(long? key)
        {
            List<MenuAccessViewModel> result = MenuAccessRepo.search(key);
            return PartialView("_ListMenuAccess", result);
        }
        public ActionResult Create()
        {
            ViewBag.RoleList = new SelectList(RoleRepo.All(null), "id", "name");
            ViewBag.MenuList = new SelectList(MenuRepo.All(null), "id", "title");
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(MenuAccessViewModel model)
        {
            ResponResultViewModel result = MenuAccessRepo.Update(model);
            return Json(new { success = result.Success, message = result.Message, entity = result.Entity }, JsonRequestBehavior.AllowGet);
        }
       public ActionResult Delete(long id)
        {
            return PartialView("_Delete", MenuAccessRepo.GetId(id));
        }
        [HttpPost]
        public ActionResult Delete(MenuAccessViewModel model)
        {
            ResponResultViewModel result = MenuAccessRepo.Delete(model.id);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    
        public ActionResult RoleList()
        {
            return PartialView("_RoleList", RoleRepo.All(null));
        }
    }
}