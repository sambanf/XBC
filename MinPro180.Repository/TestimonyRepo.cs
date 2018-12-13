using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class TestimonyRepo
    {
        public static List<TestimonyViewModel> All(string searchString)
        {
            List<TestimonyViewModel> result = new List<TestimonyViewModel>();
            using (var db = new MinProContext())
            {
                if (String.IsNullOrEmpty(searchString))
                {
                    result = (from ts in db.t_testimony
                              where ts.is_delete == false
                              select new TestimonyViewModel
                              {
                                  id = ts.id,
                                  title = ts.title,
                                  content = ts.content,
                                  is_delete = ts.is_delete
                              }).ToList();
                }
                else
                {
                    var s = from ts in db.t_testimony
                            where ts.is_delete == false
                            select new TestimonyViewModel
                            {
                                id = ts.id,
                                title = ts.title,
                                content = ts.content,
                                is_delete = ts.is_delete
                            };
                    s = s.Where(ts => ts.title.Contains(searchString));
                    result = s.ToList();
                }

            }
            return result;
        }
        public static TestimonyViewModel GetTestimony(long id)
        {
            TestimonyViewModel result = new TestimonyViewModel();
            using (var db = new MinProContext())
            {
                result = (from ts in db.t_testimony
                          where ts.id == id
                          select new TestimonyViewModel
                          {
                              id = ts.id,
                              title = ts.title,
                              content = ts.content,
                              is_delete = ts.is_delete
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new TestimonyViewModel();
                }
            }
            return result;
        }
        public static ResponResultViewModel Update(TestimonyViewModel entity)
        {
            //untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_testimony testimony = new t_testimony();
                        testimony.title = entity.title;
                        testimony.content = entity.content;
                        testimony.is_delete = entity.is_delete;

                        testimony.created_by = 1;
                        testimony.created_on = DateTime.Now;

                        db.t_testimony.Add(testimony);
                        db.SaveChanges();
                        result.Entity = testimony;
                    }
                    else
                    {
                        t_testimony testimony = db.t_testimony.Where(o => o.id == entity.id).FirstOrDefault();
                        if (testimony != null)
                        {
                            testimony.title = entity.title;
                            testimony.content = entity.content;

                            testimony.created_by = 1;
                            testimony.created_on = DateTime.Now;

                            db.SaveChanges();

                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "testimony not found!";
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

        public static ResponResultViewModel Update2(TestimonyViewModel entity)
        {
            //untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_testimony testimony = new t_testimony();
                        testimony.title = entity.title;
                        testimony.content = entity.content;
                        testimony.is_delete = entity.is_delete;

                        testimony.created_by = 1;
                        testimony.created_on = DateTime.Now;

                        db.t_testimony.Add(testimony);
                        db.SaveChanges();
                        result.Entity = testimony;
                    }
                    else
                    {
                        t_testimony testimony = db.t_testimony.Where(o => o.id == entity.id).FirstOrDefault();
                        if (testimony != null)
                        {
                            testimony.title = entity.title;
                            testimony.content = entity.content;
                            testimony.is_delete = true;

                            testimony.created_by = 1;
                            testimony.created_on = DateTime.Now;

                            db.SaveChanges();

                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "testimony not found!";
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
