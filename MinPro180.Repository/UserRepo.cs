using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinPro180.DataModel;
using MinPro180.ViewModel;

namespace MinPro180.Repository
{
    public class UserRepo
    {
        public static List<UserViewModel> All(string searchString)
        {
            List<UserViewModel> result = new List<UserViewModel>();
            using (var db = new MinProContext())
            {
                if (String.IsNullOrEmpty(searchString))
                {
                    result = (from u in db.t_user
                              join r in db.t_role on u.role_id equals r.id
                              select new UserViewModel
                              {
                                  id = u.id,
                                  username = u.username,
                                  password = u.password,
                                  role_id = r.id,
                                  role_name = r.name,
                                  mobile_flag = u.mobile_flag,
                                  mobile_token = u.mobile_token,
                                  active = u.active

                              }).ToList();
                }
                else
                {
                    var src = from s in db.t_user
                              where s.active == true
                              select new UserViewModel
                              {
                                  id = s.id,
                                  username = s.username
                              };
                    src = src.Where(s => s.username.Contains(searchString));
                    result = src.ToList();
                }

            }
            return result;
        }
        public static UserViewModel GetUser(int id)
        {
            UserViewModel result = new UserViewModel();
            using (var db = new MinProContext())
            {
                result = (from u in db.t_user
                          join r in db.t_role on u.role_id equals r.id
                          where u.id == id
                          select new UserViewModel
                          {
                              id = u.id,
                              username = u.username,
                              password = u.password,
                              role_id = r.id,
                              mobile_flag = u.mobile_flag,
                              mobile_token = u.mobile_token,
                              active = u.active

                          }).FirstOrDefault();
            }
            return result;
        }

        public static ResponResultViewModel Update(UserViewModel entity)
        {
            //untuk create & edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    if (entity.id == 0)
                    {
                        t_user user = new t_user();
                        user.username = entity.username;
                        user.password = entity.password;
                        user.role_id = entity.role_id;
                        user.mobile_flag = entity.mobile_flag;
                        user.mobile_token = entity.mobile_token;
                        user.created_by = entity.id;
                        user.created_on = DateTime.Now;
                        user.active = entity.active;

                        db.t_user.Add(user);
                        db.SaveChanges();

                        result.Entity = user;

                    }
                    else
                    {
                        t_user user = db.t_user.Where(x => x.id == entity.id).FirstOrDefault();
                        if (user != null)
                        {
                            user.username = entity.username;
                            user.password = entity.password;
                            user.role_id = entity.role_id;
                            user.mobile_flag = entity.mobile_flag;
                            user.mobile_token = entity.mobile_token;
                            user.modified_by = entity.id;
                            user.modified_on = DateTime.Now;
                            user.active = entity.active;

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

        public static ResponResultViewModel Update2(UserViewModel entity)
        {
            //untuk create dan edit
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    t_user user = db.t_user.Where(x => x.id == entity.id).FirstOrDefault();
                    if (user != null)
                    {
                        user.username = entity.username;
                        user.password = entity.password;
                        user.role_id = entity.role_id;
                        user.mobile_flag = entity.mobile_flag;
                        user.mobile_token = entity.mobile_token;
                        user.modified_by = entity.id;
                        user.modified_on = DateTime.Now;
                        user.active = false;

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

    }
}
