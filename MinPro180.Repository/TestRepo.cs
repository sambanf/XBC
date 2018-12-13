using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class TestRepo
    {
        public static List<TestViewModel> All()
        {
            List<TestViewModel> result = new List<TestViewModel>();
            using (var db = new MinProContext())
            {
                    result = (from t in db.t_test
                              where t.active == true
                              select new TestViewModel
                              {
                                  id = t.id,
                                  name = t.name,
                                  notes = t.notes,
                                  created_by = t.created_by,
                                  active = t.active
                              }).ToList();
            }
            return result;
        }

        public static List<TestViewModel> All(string code)
        {
            List<TestViewModel> result = new List<TestViewModel>();
            using (var db = new MinProContext())
            {
                result = (from t in db.t_test
                          where t.active == true
                          select new TestViewModel
                          {
                              id = t.id,
                              name = t.name,
                              notes = t.notes,
                              created_by = t.created_by,
                              active = t.active
                          }).Where(x=>x.name.Contains(code)).ToList();
            }
            return result;
        }

        public static TestViewModel Get(int id)
        {
            TestViewModel result = new TestViewModel();
            using (var db = new MinProContext())
            {
                result = (from t in db.t_test
                          where t.id == id && t.active == true
                          select new TestViewModel
                          {
                              id = t.id,
                              name = t.name,
                              notes = t.notes,
                              active = t.active
                          }).FirstOrDefault();

                //if (result == null)
                //{
                //    result = new CategoryViewModel();
                //}
            }
            return result;
        }

        public static ResponResultViewModel Update(TestViewModel entity)
        {
            //untuk create & edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_test test = new t_test();
                        test.name = entity.name;
                        test.notes = entity.notes;
                        test.active = entity.active;
                        test.created_by = 1;
                        test.created_on = DateTime.Now;

                        db.t_test.Add(test);
                        db.SaveChanges();

                        result.Entity = test;
                    }
                    else
                    {
                        t_test test = db.t_test.Where(x => x.id == entity.id).FirstOrDefault();
                        if (test != null)
                        {
                            test.name = entity.name;
                            test.notes = entity.notes;
                            test.active = entity.active;
                            test.modified_by = 1;
                            test.modified_on = DateTime.Now;

                            db.SaveChanges();
                            result.Entity = entity;
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

        public static ResponResultViewModel Deact(TestViewModel model)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            using (var db = new MinProContext())
            {
                t_test test = db.t_test.Where(x => x.id == model.id).FirstOrDefault();
                test.active = false;
                test.modified_by = 1;
                test.modified_on = DateTime.Now;
                test.name = model.name;

                try
                {
                    db.SaveChanges();
                    result.Entity = model;
                }
                catch (Exception e)
                {
                    result.Success = false;
                    result.Message = e.Message;
                }
            }
            return result;
        }
    }
}
