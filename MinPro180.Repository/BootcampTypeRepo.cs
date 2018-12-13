using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class BootcampTypeRepo
    {
        public static List<BootcampTypeViewModel> All()
        {
            List<BootcampTypeViewModel> result = new List<BootcampTypeViewModel>();
            using (var db = new MinProContext())
            {
                result = (from bt in db.t_bootcamp_type
                          select new BootcampTypeViewModel
                          {
                              id = bt.id,
                              name = bt.name,
                              notes = bt.notes,
                              created_by = bt.created_by,
                              created_on = bt.created_on,
                              active = bt.active,
                              actv = bt.active == true ? "Active":"Non Active"
                          }).ToList();
            }
            return result;
        }
        public static List<BootcampTypeViewModel> search(string key)
        {
            List<BootcampTypeViewModel> result = new List<BootcampTypeViewModel>();
            using(var db = new MinProContext())
            {
                result = (from bt in db.t_bootcamp_type
                          where bt.name.ToUpper().Contains(key.ToLower())
                          select new BootcampTypeViewModel
                          {
                              id = bt.id,
                              name = bt.name,
                              notes = bt.notes,
                              created_by = bt.created_by,
                              created_on = bt.created_on,
                              active = bt.active
                          }).ToList();
            }
            return result;
        }
        public static ResponResultViewModel Update(BootcampTypeViewModel entity)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_bootcamp_type bt = new t_bootcamp_type();
                        bt.name = entity.name;
                        bt.notes = entity.notes;
                        bt.created_by = 1;
                        bt.created_on = DateTime.Now;
                        bt.active = true;

                        db.t_bootcamp_type.Add(bt);
                        db.SaveChanges();
                        result.Entity = entity;
                    }
                    else
                    {
                        if (entity != null)
                        {
                            t_bootcamp_type bt = db.t_bootcamp_type.Where(o => o.id == entity.id).FirstOrDefault();
                            bt.name = entity.name;
                            bt.notes = entity.notes;
                            bt.modified_by = 1;
                            bt.modified_on = DateTime.Now;
                            bt.active = true;

                            db.SaveChanges();
                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Bootcamp Type Not Found";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
        public static BootcampTypeViewModel GetId(long id)
        {
            BootcampTypeViewModel result = new BootcampTypeViewModel();
            using (var db = new MinProContext())
            {
                result = (from bt in db.t_bootcamp_type
                          where bt.id == id
                          select new BootcampTypeViewModel
                          {
                              id = bt.id,
                              name = bt.name,
                              notes = bt.notes,
                              created_by = bt.created_by,
                              created_on = bt.created_on,
                              active = bt.active
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new BootcampTypeViewModel();
                }
            }
            return result;
        }
        public static ResponResultViewModel Delete(long id)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    t_bootcamp_type bt = db.t_bootcamp_type.Where(o => o.id == id).FirstOrDefault();
                    if (bt == null)
                    {
                        result.Success = false;
                        result.Message = "Bootcamp Type Not Found";
                    }
                    else
                    {
                        result.Entity = bt;
                        db.t_bootcamp_type.Remove(bt);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                result.Success = false;
                result.Message = ex.Message;
            }
            return result;
        }
    }
}
