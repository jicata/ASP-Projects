namespace JicaTweet.Data
{
    using System;
    using Repositories.Contracts;

    public interface IJicaTweetData : IDisposable
    {
        JicaTweetDbContext Context { get; }
        ITweetRepository Tweets { get; }
    }
}
