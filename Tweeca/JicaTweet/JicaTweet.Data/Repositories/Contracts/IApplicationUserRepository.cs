namespace JicaTweet.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using Base;
    using JicaTweet.Contracts;
    using Models;

    public interface IApplicationUserRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetByUsername(string username);

        ApplicationUser GetById(int id);

    }
}
