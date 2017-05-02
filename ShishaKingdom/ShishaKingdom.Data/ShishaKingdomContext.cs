namespace ShishaKingdom.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class ShishaKingdomContext : IdentityDbContext<User>, IShishaKingdomContext
    {
        public ShishaKingdomContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ShishaKingdomContext Create()
        {
            return new ShishaKingdomContext();
        }

        public DbContext DbContext => this;
        public IDbSet<Product> Products { get; set; }
        public IDbSet<Category> Categories { get; set; }
        public IDbSet<WishList> WishLists { get; set; }

        public IDbSet<Order> Orders { get; }

        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
        
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasOptional(c => c.SubCategories).WithMany();
            base.OnModelCreating(modelBuilder);
        }

      
    }
}