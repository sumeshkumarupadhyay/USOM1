namespace USOM.Migrations
{
	using Microsoft.AspNet.Identity;
	using Microsoft.AspNet.Identity.EntityFramework;
	using USOM.Models;
	using System;
	using System.Data.Entity;
	using System.Data.Entity.Migrations;
	using System.Linq;

	internal sealed class Configuration : DbMigrationsConfiguration<USOM.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(USOM.Models.ApplicationDbContext context)
        {
			var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

			userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
			{
				AllowOnlyAlphanumericUserNames = false
			};

			var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

			if (!roleManager.RoleExists("Admin"))
			{
				roleManager.Create(new IdentityRole("Admin"));
			}

			var user = new ApplicationUser()
			{
				Email = "admin@admin.com",
				UserName = "admin@admin.com",
				PhoneNumber = "9876543210",
				LockoutEnabled = true,
				EmailConfirmed = false,
			};

			var userResult = userManager.Create(user, "Admin@123");

			if (userResult.Succeeded)
			{
				userManager.AddToRole(user.Id, "Admin");
			}
			//  This method will be called after migrating to the latest version.

			//  You can use the DbSet<T>.AddOrUpdate() helper extension method
			//  to avoid creating duplicate seed data.
		}
    }
}
