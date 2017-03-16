namespace ShishaKingdom.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
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
            var wishlist = new WishList();
            var user = context.Users.FirstOrDefault();
        
            wishlist.Id = Guid.NewGuid().ToString();
            wishlist.Customer = user;
            context.SaveChanges();
        }
    }
}
