using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class TrainerRepo
    {
        public static List<TrainerViewModel> All(string searchString)
        {
            List<TrainerViewModel> result = new List<TrainerViewModel>();
            using (var db = new MinProContext())
            {
                if (String.IsNullOrEmpty(searchString))
                {

                    result = (from tr in db.t_trainer
                              where tr.active == true
                              select new TrainerViewModel
                              {
                                  id = tr.id,
                                  name = tr.name,
                                  notes = tr.notes,
                                  active = tr.active
                              }).ToList();
                }
                else
                {
                    var s = from tr in db.t_trainer
                            where tr.active == true
                            select new TrainerViewModel
                             {
                                id = tr.id,
                                name = tr.name,
                                notes = tr.notes,
                                active = tr.active
                            };
                    s = s.Where(tr => tr.name.Contains(searchString));
                    result = s.ToList();
                }

            }
            return result;
        }
        public static TrainerViewModel GetTrainer(long id)
        {
            TrainerViewModel result = new TrainerViewModel();
            using (var db = new MinProContext())
            {
                result = (from tr in db.t_trainer
                          where tr.id == id
                          select new TrainerViewModel
                          {
                              id = tr.id,
                              name = tr.name,
                              notes = tr.notes,
                              active = tr.active
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new TrainerViewModel();
                }
            }
            return result;
        }
        public static ResponResultViewModel Update(TrainerViewModel entity)
        {
            //untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_trainer trainer = new t_trainer();
                        trainer.name = entity.name;
                        trainer.notes = entity.notes;
                        trainer.active = entity.active;

                        trainer.created_by = 1;
                        trainer.created_on = DateTime.Now;

                        db.t_trainer.Add(trainer);
                        db.SaveChanges();
                        result.Entity = trainer;
                    }
                    else
                    {
                        t_trainer trainer = db.t_trainer.Where(o => o.id == entity.id).FirstOrDefault();
                        if (trainer != null)
                        {
                            trainer.name = entity.name;
                            trainer.notes = entity.notes;

                            trainer.created_by = 1;
                            trainer.created_on = DateTime.Now;

                            db.SaveChanges();

                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "trainer not found!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }

        public static ResponResultViewModel Update2(TrainerViewModel entity)
        {
            //untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_trainer trainer = new t_trainer();
                        trainer.name = entity.name;
                        trainer.notes = entity.notes;
                        trainer.active = entity.active;

                        trainer.created_by = 1;
                        trainer.created_on = DateTime.Now;

                        db.t_trainer.Add(trainer);
                        db.SaveChanges();
                        result.Entity = trainer;
                    }
                    else
                    {
                        t_trainer trainer = db.t_trainer.Where(o => o.id == entity.id).FirstOrDefault();
                        if (trainer != null)
                        {
                            trainer.name = entity.name;
                            trainer.notes = entity.notes;
                            trainer.active = false;

                            trainer.created_by = 1;
                            trainer.created_on = DateTime.Now;

                            db.SaveChanges();

                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "trainer not found!";
                        }
                    }
                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }
    }
}
