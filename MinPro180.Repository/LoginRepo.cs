using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MinPro180.DataModel;
using MinPro180.ViewModel;

namespace MinPro180.Repository
{
    public class LoginRepo
    {
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

        public static UserViewModel CheckUser(UserViewModel model)
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
        public static UserViewModel GetByUsername(string username)
        {
            UserViewModel result = new UserViewModel();
            using (MinProContext db = new MinProContext())
            {
                result = (from u in db.t_user
                          join r in db.t_role on u.role_id equals r.id
                          where u.active == true && u.username == username
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
