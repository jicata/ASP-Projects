namespace Jitter.Data.Contracts
{
    using System.Data.Entity;
    using Models;

    public interface IJitterContext
    {
        DbContext DbContext { get; }

        int SaveChanges();
        IDbSet<T> Set<T>()
           where T : class;
    }
}
