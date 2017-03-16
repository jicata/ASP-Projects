namespace ShishaKingdom.Data
{
    using Contracts;
    using Models;
    using Repositories;

    public class ShishaKingdomData : IShishaKingdomData
    {
        private readonly IShishaKingdomContext context;
        public ShishaKingdomData(IShishaKingdomContext context)
        {
            this.context = context;
        }

        public IRepository<User> Users => new Repository<User>(this.context);
        public IRepository<Product> Products => new Repository<Product>(this.context);
        public IRepository<Category> Categories => new Repository<Category>(this.context);
        public IRepository<WishList> WishLists => new Repository<WishList>(this.context);
        public IShishaKingdomContext Context => this.context;
        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }
    }
}
