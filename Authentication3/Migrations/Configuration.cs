using System.Collections.Generic;
using Authentication3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Authentication3.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Authentication3.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Authentication3.Models.ApplicationDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            AddRoles(context);
            AddUser(context);
        }

        private void AddUser(ApplicationDbContext context)
        {
            string Email = "shohag.cse3@gmail.com";
            ApplicationUser applicationUser = context.Users.FirstOrDefault(x => x.Email == Email);
            if (applicationUser == null)
            {
                var UserId = Guid.NewGuid().ToString();
                IdentityRole identityRole = context.Roles.FirstOrDefault(x => x.Name == "Admin");
                IdentityUserRole identityUserRole = new IdentityUserRole()
                {
                    UserId = UserId,
                    RoleId = identityRole.Id
                };
                PasswordHasher hasher = new PasswordHasher();
                string hashpassword = hasher.HashPassword("12345");
                applicationUser = new ApplicationUser()
                {
                    Email = Email,
                    UserName = Email,
                    Id = UserId,
                    Roles = {identityUserRole},
                    PasswordHash = hashpassword
                };
                context.Users.Add(applicationUser);
                context.SaveChanges();
            }
        }


        private void AddRoles(ApplicationDbContext context)
        {
            List<string> roles=new List<string>(){"Admin","User"};
            foreach (string arole in roles)
            {
                IdentityRole identityRole = context.Roles.FirstOrDefault(x => x.Name == arole);
                if (identityRole == null)
                {
                    identityRole=new IdentityRole(arole);
                    context.Roles.Add(identityRole);
                }
            }
            context.SaveChanges();
        }
    }
}
