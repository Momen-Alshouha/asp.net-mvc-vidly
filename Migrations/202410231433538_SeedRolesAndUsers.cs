namespace asp.net_vidly.Migrations
{
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using asp.net_vidly.Models;
    using System;
    using System.Data.Entity.Migrations;

    public partial class SeedRolesAndUsers : DbMigration
    {
        public override void Up()
        {
            var context = new ApplicationDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            if (!roleManager.RoleExists("Admin"))
            {
                roleManager.Create(new IdentityRole("Admin"));
            }

            if (!roleManager.RoleExists("User"))
            {
                roleManager.Create(new IdentityRole("User"));
            }

            if (userManager.FindByEmail("admin@example.com") == null)
            {
                var adminUser = new ApplicationUser
                {
                    UserName = "admin@example.com",
                    Email = "admin@example.com"
                };

                var result = userManager.Create(adminUser, "Admin@123");
                if (result.Succeeded)
                {
                    var createdAdminUser = userManager.FindByEmail("admin@example.com");
                    userManager.AddToRole(createdAdminUser.Id, "Admin");
                }
            }

            if (userManager.FindByEmail("user@example.com") == null)
            {
                var regularUser = new ApplicationUser
                {
                    UserName = "user@example.com",
                    Email = "user@example.com"
                };

                var result = userManager.Create(regularUser, "User@123");
                if (result.Succeeded)
                {
                    var createdRegularUser = userManager.FindByEmail("user@example.com");
                    userManager.AddToRole(createdRegularUser.Id, "User");
                }
            }
        }

        public override void Down()
        {
        }
    }
}
