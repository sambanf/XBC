using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class TechnologyRepo
    {
        public static List<TechnologyViewModel> All(string searchString)
        {
            List<TechnologyViewModel> result = new List<TechnologyViewModel>();
            using (var db = new MinProContext())
            {
                if (String.IsNullOrEmpty(searchString))
                {
                    result = (from tc in db.t_technology
                              where tc.active == true
                              select new TechnologyViewModel
                              {
                                  id = tc.id,
                                  name = tc.name,
                                  notes = tc.notes,
                                  created_by = tc.created_by,
                                  active = tc.active
                              }).ToList();
                }
                else
                {
                    var s = from tc in db.t_technology
                            where tc.active == true
                            select new TechnologyViewModel
                            {
                                id = tc.id,
                                name = tc.name,
                                notes = tc.notes,
                                created_by = tc.created_by,
                                active = tc.active
                            };
                    s = s.Where(tc => tc.name.Contains(searchString));
                    result = s.ToList();
                }
            }
            return result;
        }
        public static TechnologyViewModel GetTechnology(long id)
        {
            TechnologyViewModel result = new TechnologyViewModel();
            using (var db = new MinProContext())
            {
                result = (from tc in db.t_technology
                          where tc.id == id
                          select new TechnologyViewModel
                          {
                              id = tc.id,
                              name = tc.name,
                              notes = tc.notes,
                              active = tc.active
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new TechnologyViewModel();
                }
            }
            return result;
        }

        //public static TechnologyTrainerViewModel GetTechnology2(long id)
        //{
        //    TechnologyTrainerViewModel result = new TechnologyTrainerViewModel();
        //    using (var db = new MinProContext())
        //    {
        //        result = (from tc in db.t_technology
        //                  join tt in db.t_technology_trainer on tc.id equals tt.technology_id
        //                  where tc.id == id
        //                  select new TechnologyTrainerViewModel
        //                  {
        //                      id = tc.id,
        //                      name = tc.name,
        //                      notes = tc.notes,
        //                      active = tc.active,
        //                      trainer_id = tt.trainer_id
        //                  }).FirstOrDefault();
        //        if (result == null)
        //        {
        //            result = new TechnologyTrainerViewModel();
        //        }
        //    }
        //    return result;
        //}

        public static ResponResultViewModel Update(TechnologyViewModel entity)
        {
            //untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_technology technology = new t_technology();
                        technology.name = entity.name;
                        technology.notes = entity.notes;
                        technology.active = entity.active;

                        technology.created_by = 1;
                        technology.created_on = DateTime.Now;

                        foreach (var tr in entity.trainer)
                        {
                            t_technology_trainer tt = new t_technology_trainer();
                            tt.technology_id = technology.id;
                            tt.trainer_id = tr.id;

                            tt.created_by = 1;
                            tt.created_on = DateTime.Now;

                            db.t_technology_trainer.Add(tt);

                            result.Entity = entity;
                        }

                        db.t_technology.Add(technology);
                        db.SaveChanges();
                    }
                    else
                    {
                        t_technology technology = db.t_technology.Where(o => o.id == entity.id).FirstOrDefault();
                        if (technology != null)
                        {
                            technology.name = entity.name;
                            technology.notes = entity.notes;
                            technology.active = entity.active;

                            technology.created_by = 1;
                            technology.created_on = DateTime.Now;

                            foreach (var tr in entity.trainer)
                            {
                                t_technology_trainer tt = new t_technology_trainer();
                                tt.technology_id = technology.id;
                                tt.trainer_id = tr.id;

                                tt.created_by = 1;
                                tt.created_on = DateTime.Now;

                                db.t_technology_trainer.Add(tt);

                                result.Entity = entity;
                            }

                            db.SaveChanges();
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "technology not found!";
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

        public static ResponResultViewModel Update2(TechnologyViewModel entity)
        {
            //untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_technology technology = new t_technology();
                        technology.name = entity.name;
                        technology.notes = entity.notes;
                        technology.active = entity.active;

                        technology.created_by = 1;
                        technology.created_on = DateTime.Now;

                        db.t_technology.Add(technology);
                        db.SaveChanges();
                        result.Entity = technology;
                    }
                    else
                    {
                        t_technology technology = db.t_technology.Where(o => o.id == entity.id).FirstOrDefault();
                        if (technology != null)
                        {
                            technology.name = entity.name;
                            technology.notes = entity.notes;
                            technology.active = false;

                            technology.created_by = 1;
                            technology.created_on = DateTime.Now;

                            db.SaveChanges();

                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "technology not found!";
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

       
        public static List<TrainerViewModel> Detail()
        {
            List<TrainerViewModel> result = new List<TrainerViewModel>();

            return result;
        }

        public static TrainerViewModel Detailtrainer(int id)
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
                              created_by = tr.created_by,
                              active = tr.active
                          }).FirstOrDefault();
            }
            return result == null ? new TrainerViewModel() : result;
        }

        public static List<TrainerViewModel> Detail2()
        {
            List<TrainerViewModel> result = new List<TrainerViewModel>();

            return result;
        }

    }
}