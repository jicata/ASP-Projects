namespace JicaTweet.Data.Repositories.Contracts
{
    using System.Collections.Generic;
    using JicaTweet.Contracts;
    using Models;
    public interface ITweetRepository : IRepository<Tweet>
    {
        IEnumerable<Tweet> TweetsByAuthor(string authorUsername);
        Tweet TweetById(int id);
        IEnumerable<Tweet> TweetsInDateRange(string lowerBoundDate, string upperBoundDate);
    }
}
