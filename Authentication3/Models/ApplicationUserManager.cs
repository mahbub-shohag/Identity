using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace Authentication3.Models
{
    public class ApplicationUserManager:UserManager<ApplicationUser>
    {
        public ApplicationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
        }

        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options,IOwinContext context)
        {
            ApplicationDbContext dbContext = context.Get<ApplicationDbContext>();
            IUserStore<ApplicationUser> store=new UserStore<ApplicationUser>(dbContext);
            ApplicationUserManager manager=new ApplicationUserManager(store);
           /* manager.UserValidator = new UserValidator<ApplicationUser>()
            {
                AllowOnlyAlphanumericUserNames = true,
                RequireUniqueEmail = true

            };*/
            manager.PasswordValidator = new PasswordValidator() {RequiredLength = 6};
            return manager;
        }
    }
}