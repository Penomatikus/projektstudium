using DeviceReg.Common.Data.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DeviceReg.Common.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<DeviceReg.Common.Data.DeviceRegDB.DeviceRegDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(DeviceReg.Common.Data.DeviceRegDB.DeviceRegDBContext context)
        {
            // check whether role is already in db
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            // check whether user is already in db
            if (!context.Users.Any(u => u.UserName == "admin@admin.de"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@admin.de" };

                /*
                 * Important note: user name and password have to match the given criteria in AccountBindungModels.cs.
                 * Otherwise the user creation will fail without any error messages.
                 * */

                manager.Create(user, "Admin123!");
                manager.AddToRole(user.Id, "admin");
            }
        }
    }
}
