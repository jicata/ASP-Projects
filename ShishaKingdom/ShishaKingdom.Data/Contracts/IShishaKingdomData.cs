namespace ShishaKingdom.Data.Contracts
{
    using Models;

    public interface IShishaKingdomData
    {
        IRepository<User> Users { get; }
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IRepository<WishList> WishLists { get; }
        IRepository<Order> Orders { get; }
        IShishaKingdomContext Context { get; }

        int SaveChanges();
    }
}
