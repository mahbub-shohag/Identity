using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Authentication3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;

namespace Authentication3.Controllers
{
    public class AccountController : Controller
    {
        
        public ActionResult Login()
        {
            LoginModel model = new LoginModel();

            return View(model);
        }
        [HttpPost]
        public ActionResult Login(LoginModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            ApplicationSignInManager signInManager = Request.GetOwinContext().Get<ApplicationSignInManager>();
            SignInStatus signInStatus = signInManager.PasswordSignIn(model.Email, model.Password, false, false);
            switch (signInStatus)
            {
                case SignInStatus.Success:
                    return Redirect("/");
                default:
                    ModelState.AddModelError("","Invalid Login Attempt");
                    return View(model);
            }

        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);

            }
            ApplicationUserManager userManager = Request.GetOwinContext().Get<ApplicationUserManager>();
            ApplicationUser user = new ApplicationUser()
            {
                Email = model.Email,
                PasswordHash = new PasswordHasher().HashPassword(model.Password),
                UserName = model.Email
            };
            IdentityResult result = userManager.Create(user);
            if (result.Succeeded)
            {
                ApplicationSignInManager signinManager = Request.GetOwinContext().Get<ApplicationSignInManager>();
                signinManager.SignIn(user,false,false);
               return RedirectToAction("Index", "Home");

            }
            return View(model);
        }

	}
}