using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class IdleRepo
    {
        public static List<IdleViewModel> All()
        {
            List<IdleViewModel> result = new List<IdleViewModel>();
            using (var db = new MinProContext())
            {
                result = (from idl in db.t_idle_news
                          join c in db.t_category on
                          idl.category_id equals c.id
                          where idl.is_delete == false &&
                          idl.is_publish == false
                          select new IdleViewModel
                          {
                              id = idl.id,
                              category_id = idl.category_id,
                              category = c.name,
                              title = idl.title,
                              content = idl.content
                          }).ToList();
            }
            return result;
        }
        public static List<IdleViewModel> search(string key)
        {
            List<IdleViewModel> result = new List<IdleViewModel>();
            using(var db = new MinProContext())
            {
                result = (from idl in db.t_idle_news
                          where idl.title.ToUpper().Contains(key.ToLower())
                          && idl.is_delete == false && idl.is_publish == false
                          select new IdleViewModel
                          {
                              id = idl.id,
                              category_id = idl.category_id,
                              title = idl.title,
                              content = idl.content
                          }).ToList();
            }
            return result;
        }
        public static ResponResultViewModel Update(IdleViewModel entity)
        {
            //create - edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_idle_news idl = new t_idle_news();
                        idl.title = entity.title;
                        idl.category_id = entity.category_id;
                        idl.content = entity.content;
                        idl.is_publish = false;
                        idl.created_by = 1;
                        idl.created_on = DateTime.Now;
                        idl.is_delete = false;

                        db.t_idle_news.Add(idl);
                        db.SaveChanges();
                        result.Entity = entity;
                    }
                    else
                    {
                        t_idle_news idl = db.t_idle_news.Where(o => o.id == entity.id).FirstOrDefault();
                        if (idl != null)
                        {
                            idl.title = entity.title;
                            idl.category_id = entity.category_id;
                            idl.content = entity.content;
                            idl.modified_by = 1;
                            idl.modified_on = DateTime.Now;

                            db.SaveChanges();
                            result.Entity = entity;
                        }
                        else
                        {
                            result.Success = false;
                            result.Message = "Idle Not Found";
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
        public static IdleViewModel GetId(long id)
        {
            IdleViewModel result = new IdleViewModel();
            using (var db = new MinProContext())
            {
                result = (from idl in db.t_idle_news
                          where idl.id == id
                          select new IdleViewModel
                          {
                              id = idl.id,
                              title = idl.title,
                              category_id = idl.category_id,
                              content = idl.content
                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new IdleViewModel();
                }
            }
            return result;
        }

        public static ResponResultViewModel isdelete(IdleViewModel entity)
        {
            //create - edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        result.Message = "Data Not Found";
                    }
                    else
                    {
                        t_idle_news idl = db.t_idle_news.Where(o => o.id == entity.id).FirstOrDefault();
                        if (idl != null)
                        {
                            idl.title = entity.title;
                            idl.category_id = entity.category_id;
                            idl.content = entity.content;
                            idl.modified_by = 1;
                            idl.modified_on = DateTime.Now;
                            idl.is_delete = true;
                            idl.deleted_by = 2;
                            idl.deleted_on = DateTime.Now;

                            db.SaveChanges();
                            result.Entity = entity;
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
        public static ResponResultViewModel ispublish(IdleViewModel entity)
        {
            //create - edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        result.Message = "Data Not Found";
                    }
                    else
                    {
                        t_idle_news idl = db.t_idle_news.Where(o => o.id == entity.id).FirstOrDefault();
                        if (idl != null)
                        {
                            idl.title = entity.title;
                            idl.category_id = entity.category_id;
                            idl.content = entity.content;
                            idl.is_publish = true;
                            idl.modified_by = 1;
                            idl.modified_on = DateTime.Now;

                            db.SaveChanges();
                            result.Entity = entity;
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
    }
}
