namespace ShishaKingdom.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<ShishaKingdom.Data.ShishaKingdomContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ShishaKingdom.Data.ShishaKingdomContext";
        }

        protected override void Seed(ShishaKingdom.Data.ShishaKingdomContext context)
        {
            if (!context.Roles.Any())
            {
                var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
                roleManager.Create(new IdentityRole("Admin"));
            }
            var userManager = new UserManager<User>(new UserStore<User>(context));
            var user = userManager.FindByEmail("ji@ca.taa");
            if (user != null)
            {
                userManager.AddToRole(user.Id, "Admin");
            }


        }
    }
}
