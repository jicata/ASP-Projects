﻿namespace ShishaKingdom.Data.Contracts
{
    using Models;

    public interface IShishaKingdomData
    {
        IRepository<User> Users { get; }
        IRepository<Product> Products { get; }
        IRepository<Category> Categories { get; }
        IShishaKingdomContext Context { get; }

        int SaveChanges();
    }
}