using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class ClassRepo
    {
        public static List<ClassViewModel> All()
        {
            List<ClassViewModel> result = new List<ClassViewModel>();
            using (var db = new MinProContext())
            {
                result = (from c in db.t_clazz
                          join b in db.t_batch on c.batch_id equals b.id
                          join s in db.t_biodata on c.biodata_id equals s.id
                          join t in db.t_technology on b.technology_id equals t.id
                          select new ClassViewModel
                          {
                              id = c.id,
                              batch_id = c.id,
                              batchname = b.name,
                              techname=t.name,
                              biodata_id = c.id,
                              bioname = s.name
                          }).ToList();
            }
            return result;
        }

        public static ClassViewModel Get(int id)
        {
            ClassViewModel result = new ClassViewModel();
            using (var db = new MinProContext())
            {
                result = (from c in db.t_clazz
                          join b in db.t_batch on c.batch_id equals b.id
                          join s in db.t_biodata on c.biodata_id equals s.id
                          where c.id == id
                          select new ClassViewModel
                          {
                              id = c.id,
                              batch_id = c.id,
                              batchname = b.name,
                              biodata_id = c.id,
                              bioname = s.name
                          }).FirstOrDefault();

                //if (result == null)
                //{
                //    result = new CategoryViewModel();
                //}
            }
            return result;
        }

        public static ResponResultViewModel Update(ClassViewModel entity)
        {
            //untuk create & edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                        t_clazz clazz = new t_clazz();
                        clazz.batch_id = entity.id;
                        clazz.biodata_id = entity.id;
                        clazz.created_by = 1;
                        clazz.created_on = DateTime.Now;

                        db.t_clazz.Add(clazz);
                        db.SaveChanges();

                        result.Entity = clazz;
                    
                }
            }
            catch (Exception e)
            {
                result.Success = false;
                result.Message = e.Message;
            }
            return result;
        }

        //public static ResponResultViewModel Deact(ClassViewModel model)
        //{
        //    ResponResultViewModel result = new ResponResultViewModel();
        //    using (var db = new MinProContext())
        //    {
        //        t_clazz Class = db.t_clazz.Where(x => x.id == model.id).FirstOrDefault();
        //        Class.active = false;
        //        Class.modified_by = 1;
        //        Class.modified_on = DateTime.Now;
        //        Class.name = model.name;

        //        try
        //        {
        //            db.SaveChanges();
        //            result.Entity = model;
        //        }
        //        catch (Exception e)
        //        {
        //            result.Success = false;
        //            result.Message = e.Message;
        //        }
        //    }
        //    return result;
        //}
    }
}
