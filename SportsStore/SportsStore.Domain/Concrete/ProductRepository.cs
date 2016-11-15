namespace SportsStore.Domain.Concrete
{
    using System.Linq;
    using Abstract;
    using Models;

    public class ProductRepository : IProductRepository
    {
        private SportsStoreContext context = new SportsStoreContext();
        public IQueryable<Product> Products { get { return this.context.Products; } }
    }
}
