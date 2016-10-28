using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Authentication3.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Authentication3.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext() : base("Authentication3")
        {
            
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}