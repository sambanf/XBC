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
        public static List<TechnologyViewModel> All()
        {
            List<TechnologyViewModel> result = new List<TechnologyViewModel>();
            using (var db = new MinProContext())
            {
                result = (from tc in db.t_technology
                          where tc.active == true
                          select new TechnologyViewModel
                          {
                              id = tc.id,
                              name = tc.name,
                              notes = tc.notes,
                              active = tc.active
                          }).ToList();
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
    }
}