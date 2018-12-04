using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinPro180.DataModel;
using MinPro180.ViewModel;

namespace MinPro180.Repository
{
    public class RoleRepo
    {
        public static List<RoleViewModel> All()
        {
            List<RoleViewModel> result = new List<RoleViewModel>();
            using (var db = new MinProContext())
            {
                result = (from r in db.t_role
                          select new RoleViewModel
                          {
                              id = r.id,
                              code=r.code,
                              name=r.name,
                              description=r.description,
                              active = r.active

                          }).ToList();
            }
            return result;
        }
        public static RoleViewModel GetUser(int id)
        {
            RoleViewModel result = new RoleViewModel();
            using (var db = new MinProContext())
            {
                result = (from r in db.t_role
                          select new RoleViewModel
                          {
                              id = r.id,
                              code = r.code,
                              name = r.name,
                              description = r.description,
                              active = r.active
                          }).FirstOrDefault();
            }
            return result;
        }

        public static ResponResultViewModel Update(RoleViewModel entity)
        {
            //untuk create & edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_role role = new t_role();
                        role.id = entity.id;
                        role.code = entity.code;
                        role.name = entity.name;
                        role.description = entity.description;
                        role.created_by = entity.id;
                        role.created_on = DateTime.Now;
                        role.active = entity.active;

                        db.t_role.Add(role);
                        db.SaveChanges();

                        result.Entity = role;

                    }
                    else
                    {
                        t_role role = db.t_role.Where(x => x.id == entity.id).FirstOrDefault();
                        if (role != null)
                        {
                            role.id = entity.id;
                            role.code = entity.code;
                            role.name = entity.name;
                            role.description = entity.description;
                            role.modified_by = entity.id;
                            role.modified_on = DateTime.Now;
                            role.active = entity.active;

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
    }
}
