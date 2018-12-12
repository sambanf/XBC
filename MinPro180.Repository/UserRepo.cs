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
                              where u.active == true
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
                    var src = from u in db.t_user
                              join r in db.t_role on u.role_id equals r.id
                               where u.active == true
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

        public static ResponResultViewModel Update(UserViewModel entity, long userid)
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
                        user.created_by = userid;
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
                            user.modified_by = userid;
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

        public static ResponResultViewModel Deactive(UserViewModel entity, long userid)
        {
            //untuk deactive
            ResponResultViewModel result = new ResponResultViewModel();
            try
            {
                using (var db = new MinProContext())
                {
                    t_user user = db.t_user.Where(x => x.id == entity.id).FirstOrDefault();
                    if (user != null)
                    {
                        user.active = false;
                        user.modified_by = userid;
                        user.modified_on = DateTime.Now;
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

        public static LoginViewModelcs LoginCheck(LoginViewModelcs model)
        {
            using (MinProContext db = new MinProContext())
            {
                LoginViewModelcs result = new LoginViewModelcs();

                result = (from f in db.t_user
                          where f.username == model.username && f.password == model.password
                          select new LoginViewModelcs
                          {
                              username = f.username,
                              password = f.password
                          }).FirstOrDefault();

                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        public static UserViewModel CheckUser(ForgotPasswordViewModel model)
        {
            UserViewModel result = new UserViewModel();

            //check user ada atau tidak
            using (MinProContext db = new MinProContext())
            {
                result = (from f in db.t_user
                          where f.username == model.username
                          select new UserViewModel
                          {
                              id = f.id,
                              username = f.username,
                              password = model.password
                          }).FirstOrDefault();
            }
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public static UserViewModel CheckUser(UserViewModel model)
        {
            UserViewModel result = new UserViewModel();

            //check user ada atau tidak
            using (MinProContext db = new MinProContext())
            {
                result = (from f in db.t_user
                          where f.username == model.username && f.active==true
                          select new UserViewModel
                          {
                              id = f.id,
                              username = f.username,
                              password = model.password
                          }).FirstOrDefault();
            }
            if (result != null)
            {
                return result;
            }
            else
            {
                return null;
            }

        }

        public static bool Update2(UserViewModel model)
        {
            bool result = false;

            using (MinProContext db = new MinProContext())
            {
                t_user user = db.t_user.Find(model.id);
                user.username = model.username;
                user.password = model.password;
                user.role_id = model.role_id;
                user.mobile_flag = model.mobile_flag;
                user.mobile_token = model.mobile_token;
                user.created_by = model.id;
                user.created_on = DateTime.Now;
                user.modified_by = model.id;
                user.modified_on = DateTime.Now;
                user.active = model.active;

                try
                {
                    db.SaveChanges();
                    result = true;
                }
                catch (Exception e)
                {
                    result = false;
                }
            }


            return result;
        }

        public static UserViewModel GetByUsername(string username)
        {
            UserViewModel result = new UserViewModel();
            using (MinProContext db = new MinProContext())
            {
                result = (from u in db.t_user
                          join r in db.t_role on u.role_id equals r.id
                          where u.active == true
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
                          }).FirstOrDefault();
            }

            return result;
        }
    }
}
