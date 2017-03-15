namespace ShishaKingdom.Data.Contracts
{
    using System.Data.Entity;

    public interface IShishaKingdomContext
    {
        DbContext DbContext { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
