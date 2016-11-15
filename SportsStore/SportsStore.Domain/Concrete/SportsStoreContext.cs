namespace SportsStore.Domain.Concrete
{
    using System.Data.Entity;
    using Models;

    public class SportsStoreContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
    }
}
