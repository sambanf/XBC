using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MinPro180.Repository;
using MinPro180.ViewModel;

namespace MinPro180.MVC.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index(string search)
        {
            return View(UserRepo.All(search));
        }
        // List
        public ActionResult List(string search)
        {
            return PartialView("_List", UserRepo.All(search));
        }
        //Create
        public ActionResult Create()
        {
            ViewBag.ListRole = new SelectList(RoleRepo.All(null), "id", "name");//untuk dropdownlist
            return PartialView("_Create");
        }
        [HttpPost]
        public ActionResult Create(UserViewModel model)
        {
            ViewBag.ListRole = new SelectList(RoleRepo.All(null), "id", "name");//untuk dropdownlist
            ResponResultViewModel result = UserRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        //Edit
        public ActionResult Edit(int id)
        {
            ViewBag.ListRole = new SelectList(RoleRepo.All(null), "id", "name");//untuk dropdownlist
            return PartialView("_Edit", UserRepo.GetUser(id));
        }
        [HttpPost]
        public ActionResult Edit(UserViewModel model)
        {
            ViewBag.ListRole = new SelectList(RoleRepo.All(null), "id", "name");//untuk dropdownlist
            ResponResultViewModel result = UserRepo.Update(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }
        public ActionResult Deactive(int id)
        {
            return PartialView("_Deactive", UserRepo.GetUser(id));
        }
        [HttpPost]
        public ActionResult Deactive(UserViewModel model)
        {
            ResponResultViewModel result = UserRepo.Deactive(model);
            return Json(new
            {
                success = result.Success,
                message = result.Message,
                entity = result.Entity
            }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult Login()
        {
            if (this.Request.IsAuthenticated)
            {
                return RedirectToAction("Index");
            }
            return PartialView();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModelcs model)
        {
            if (ModelState.IsValid)
            {
                var user = UserRepo.LoginCheck(model);
                if (user != null)
                {
                    SignInAsync(model.username);
                    UserViewModel item = UserRepo.GetByUsername(model.username);
                    Session["User"] = item;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login");
                }
            }
            return PartialView(model);
        }

        public ActionResult Logout()
        {
            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;

            authenticationManager.SignOut();
            Session.Clear();
            Session.Abandon();

            return RedirectToAction("Login");
        }

        [AllowAnonymous]
        public ActionResult ForgotPassword()
        {
            return PartialView();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult ForgotPassword(ForgotPasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                //kalo user ada maka update info user/ganti password
                var user = UserRepo.CheckUser(model);
                if (user != null)
                {
                    if (UserRepo.Update2(user))
                    {
                        //setelah update otomatis login
                        SignInAsync(user.username);
                        return RedirectToAction("Index");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Invalid Login");
                }
            }
            return PartialView(model);
        }

        private void SignInAsync(string username)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, username));
            var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);

            var ctx = Request.GetOwinContext();
            var authenticationManager = ctx.Authentication;
            authenticationManager.SignIn(id);

        }
    }
}