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
                          where r.active == true
                          select new RoleViewModel
                          {
                              id = r.id,
                              code = r.code,
                              name = r.name,
                              description = r.description,
                              active = r.active

                          }).ToList();
            }
            return result;
        }
        public static RoleViewModel GetRole(int id)
        {
            RoleViewModel result = new RoleViewModel();
            using (var db = new MinProContext())
            {
                result = (from r in db.t_role
                          where r.id == id
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
            entity.code = GetNewRole();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_role role = new t_role();
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
        public static ResponResultViewModel Deactive(RoleViewModel entity)
        {
            //untuk deactive
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    t_role role = db.t_role.Where(x => x.id == entity.id).FirstOrDefault();
                    if (role != null)
                    {
                        role.active = false;

                        db.SaveChanges();
                        result.Entity = entity;
                    }
                    else
                    {
                        result.Success = false;
                        result.Message = "user not found!";
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
        public static string GetNewRole()
        {
            string newRole = String.Format("RO");

            using (var db = new MinProContext())
            {
                var result = (from r in db.t_role
                              where r.code.Contains(newRole) //contains: check newRev ada atau tidak pada bulan dan tahun itu
                              select new { Code = r.code }).OrderByDescending(x => x.Code).FirstOrDefault();
                if (result != null)
                {
                    string[] lastRef = result.Code.Split('O');
                    newRole += (int.Parse(lastRef[1]) + 1).ToString("D3");
                }
                else
                {
                    newRole += "001";
                }
            }
            return newRole;
        }
    }
}
