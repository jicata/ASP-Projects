namespace ShishaKingdom.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IShishaKingdomContext
    {
        DbContext DbContext { get; }

        IDbSet<Product> Products { get; }

        IDbSet<Category> Categories { get; }

        IDbSet<WishList> WishLists { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
