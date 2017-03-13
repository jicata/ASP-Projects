namespace Jitter.Data.Contracts
{
    using IdentityModels;
    using Models;
    using Repositories;

    public interface IJitterData
    {
        IRepository<User> Users { get; }
        IRepository<Jeet> Jeets { get; }
        IJitterContext Context { get; }

        int SaveChanges();
    }
}
