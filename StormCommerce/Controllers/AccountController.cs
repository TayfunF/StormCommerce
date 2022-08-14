using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using StormCommerce.Identity;
using StormCommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StormCommerce.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private RoleManager<ApplicationRole> RoleManager;

        public AccountController()
        {
            var UserStore = new UserStore<ApplicationUser>(new IdentityAppDbContext());
            UserManager = new UserManager<ApplicationUser>(UserStore);
            var RoleStore = new RoleStore<ApplicationRole>(new IdentityAppDbContext());
            RoleManager = new RoleManager<ApplicationRole>(RoleStore);
        }

        // GET: Account
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(Register Register)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser User = new ApplicationUser();
                User.Name = Register.Name;
                User.Surname = Register.Surname;
                User.Email = Register.Email;
                User.UserName = Register.Username;

                var Result = UserManager.Create(User, Register.Password);

                if (Result.Succeeded)
                {
                    //Kullanıcı Oluştu ve Kullanıcıyı Bir Role Atayabilirim
                    if (RoleManager.RoleExists("User"))
                    {
                        UserManager.AddToRole(User.Id, "User");
                    }
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    ModelState.AddModelError("WhileUserCreateError", "Kullanıcı Oluşturma Hatası");
                }
            }

            return View(Register);
        }

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Login Login)
        {
            if (ModelState.IsValid)
            {
                var User = UserManager.Find(Login.Username, Login.Password);

                if (User != null)
                {
                    //Kullanıcı varsa. Var olan kullanıcıyı sisteme dahil et
                    //ApplicationCokkie oluştur ve sisteme bırak

                    var AuthManager = HttpContext.GetOwinContext().Authentication;
                    var IdentityClaims = UserManager.CreateIdentity(User, "ApplicationCokkie");
                    var AuthProperties = new AuthenticationProperties();
                    AuthProperties.IsPersistent = Login.RememberMe;
                    AuthManager.SignIn(AuthProperties, IdentityClaims);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("LoginUserError", "Böyle Bir Kullanıcı Yok");
                }
            }

            return View(Login);
        }

        public ActionResult Logout()
        {
            var AuthManager = HttpContext.GetOwinContext().Authentication;
            AuthManager.SignOut();

            return RedirectToAction("Index", "Home");
        }
    }
}