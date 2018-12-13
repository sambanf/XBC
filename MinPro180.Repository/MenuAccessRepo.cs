using MinPro180.DataModel;
using MinPro180.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinPro180.Repository
{
    public class MenuAccessRepo
    {
        public static List<MenuAccessViewModel> All()
        {

            List<MenuAccessViewModel> result = new List<MenuAccessViewModel>();
            using (var db = new MinProContext())
            {
                    result = (from ma in db.t_menu_access
                              join r in db.t_role on
                              ma.role_id equals r.id
                              join m in db.t_menu on
                              ma.menu_id equals m.id
                              select new MenuAccessViewModel
                              {
                                  id = ma.id,
                                  menu_id = ma.menu_id,
                                  title = m.title,
                                  role_id = ma.role_id,
                                  name = r.name,
                                  created_by = ma.created_by,
                                  created_on = ma.created_on
                              }).ToList();
            }
            return result;
        }
        public static List<MenuAccessViewModel> search(long? key)
        {
            List<MenuAccessViewModel> result = new List<MenuAccessViewModel>();
            using(var db = new MinProContext())
            {
                result = (from ma in db.t_menu_access
                          join r in db.t_role on
                          ma.role_id equals r.id
                          join m in db.t_menu on
                          ma.menu_id equals m.id
                          where ma.role_id == key
                          select new MenuAccessViewModel
                          {
                              id = ma.id,
                              menu_id = ma.menu_id,
                              title = m.title,
                              role_id = ma.role_id,
                              name = r.name,
                          }).ToList();
            }
            return result;
        }
        public static MenuAccessViewModel GetId(long id)
        {
            MenuAccessViewModel result = new MenuAccessViewModel();
            using (var db = new MinProContext())
            {

                result = (from ma in db.t_menu_access
                          select new MenuAccessViewModel
                          {
                              id = ma.id,
                              menu_id = ma.id,
                              role_id = ma.role_id,

                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new MenuAccessViewModel();
                }
            }
            return result;
        }
        public static ResponResultViewModel Update(MenuAccessViewModel entity)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_menu_access ma = new t_menu_access();
                        ma.menu_id = entity.menu_id;
                        ma.role_id = entity.role_id;
                        ma.created_by = 1;
                        ma.created_on = DateTime.Now;

                        db.t_menu_access.Add(ma);
                        db.SaveChanges();
                        result.Entity = entity;
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
        public static ResponResultViewModel Delete(long id)
        {
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    t_menu_access ma = db.t_menu_access.Where(o => o.id == id).FirstOrDefault();
                    if (ma == null)
                    {
                        result.Success = false;
                        result.Message = "Menu Access Not Found";
                    }
                    else
                    {
                        result.Entity = ma;
                        db.t_menu_access.Remove(ma);
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
        public static MenuAccessViewModel Role_Id(long role_id)
        {
            MenuAccessViewModel result = new MenuAccessViewModel();
            using (var db = new MinProContext())
            {

                result = (from ma in db.t_menu_access
                          where ma.role_id == role_id
                          select new MenuAccessViewModel
                          {
                              id = ma.id,
                              menu_id = ma.id,
                              role_id = ma.role_id,

                          }).FirstOrDefault();
                if (result == null)
                {
                    result = new MenuAccessViewModel();
                }
            }
            return result;
        }
    }
}
