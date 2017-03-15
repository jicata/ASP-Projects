namespace ShishaKingdom.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class ShishaKingdomContext : IdentityDbContext<User>, IShishaKingdomContext
    {
        public ShishaKingdomContext()
            : base("ShishaKingdom")//, throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Product> Products { get; set; }
        public DbContext DbContext => this;
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static ShishaKingdomContext Create()
        {
            return new ShishaKingdomContext();
        }
    }
}