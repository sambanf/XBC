using MinPro180.Repository;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MinPro180.MVC.Controllers
{
    public class BatchController : Controller
    {
        // GET: Batch
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            return PartialView("_List", BatchRepo.All());
        }

        public ActionResult Search(string code)
        {
            List<BatchViewModel> item = BatchRepo.All(code);
            return PartialView("_List", item);
        }

        public ActionResult Create()
        {
            ViewBag.Technology=new SelectList(TechnologyRepo.All(), "id", "name");
            ViewBag.Trainer = new SelectList(TrainerRepo.All(), "id", "name");
            ViewBag.BootcampType = new SelectList(BootcampTypeRepo.All(), "id", "name");
            ViewBag.Room = new SelectList(RoomRepo.All(), "id", "name");
            return PartialView("_Create");
        }

        [HttpPost]
        public ActionResult Create(BatchViewModel model)
        {
            ResponResultViewModel result = BatchRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int id)
        {
            ViewBag.Technology=new SelectList(TechnologyRepo.All(), "id", "name");
            ViewBag.Trainer = new SelectList(TrainerRepo.All(), "id", "name");
            ViewBag.BootcampType = new SelectList(BootcampTypeRepo.All(), "id", "name");
            ViewBag.Room = new SelectList(RoomRepo.All(), "id", "name");
            return PartialView("_Update", BatchRepo.Get(id));
        }

        [HttpPost]
        public ActionResult Update(BatchViewModel model)
        {
            //if (ModelState.IsValid)
            //{
                ResponResultViewModel result = BatchRepo.Update(model);
                return Json(new
                {
                    success = result.Success,
                    message = result.Message,
                    entity = result.Entity
                }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult IndexClass()
        {
            return View(BatchRepo.ListParticipant());
        }

        public ActionResult ListPart()
        {
            return PartialView("_ListPart", BatchRepo.ListParticipant());
        }

        public ActionResult SearchClass(string code)
        {
            List<ClassViewModel> item = BatchRepo.ListParticipant(code);
            return PartialView("_ListPart", item);
        }

        public ActionResult CreatePart(int id)
        {
            //id=>Batch ID
            ClassViewModel model = new ClassViewModel()
            {
                batch_id = id
            };
            ViewBag.BioName = new SelectList(BiodataRepo.All(null), "id", "name");
            return PartialView("_CreatePart", model);
        }

        [HttpPost]
        public ActionResult CreatePart(ClassViewModel model)
        {
            ResponResultViewModel result = BatchRepo.AddParticipant(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult DeleteParticipant(int id)
        {
            return PartialView("_DeletePart", BatchRepo.GetBatch(id));
        }

        [HttpPost]
        public ActionResult DeleteParticipant(ClassViewModel model)
        {
            ResponResultViewModel result = BatchRepo.DeletePart(model.id);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
    }
}