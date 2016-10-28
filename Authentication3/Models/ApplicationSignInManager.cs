using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Authentication3.Models
{
    public class ApplicationSignInManager : SignInManager<ApplicationUser,string>
    {
        public ApplicationSignInManager(UserManager<ApplicationUser, string> userManager, Microsoft.Owin.Security.IAuthenticationManager authenticationManager) : base(userManager, authenticationManager)
        {
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager>options,IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(),context.Authentication);
        }
    }
}