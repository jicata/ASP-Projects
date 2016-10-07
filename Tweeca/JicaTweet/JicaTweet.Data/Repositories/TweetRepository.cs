namespace JicaTweet.Data.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Base;
    using Contracts;
    using Models;
    public class TweetRepository : GenericRepository<Tweet>, ITweetRepository
    {
        public TweetRepository(JicaTweetDbContext context) : base(context)
        {
        }

        public IEnumerable<Tweet> TweetsByAuthor(string authorUsername)
        {
            var tweetsByAuthor = this.Context.Tweets.Where(t => t.Author == authorUsername);
            foreach (var tweet in tweetsByAuthor)
            {
                yield return tweet;
            }
        }

        public Tweet TweetById(int id)
        {
            return this.Context.Tweets.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Tweet> TweetsInDateRange(string lowerBoundDate, string upperBoundDate)
        {
            DateTime startDate = DateTime.Parse(lowerBoundDate);
            DateTime endDate = DateTime.Parse(upperBoundDate);
            var tweetsInDateRange =
                this.Context.Tweets.Where(t => t.DateOfCreation >= startDate && t.DateOfCreation <= endDate);
            foreach (var tweet in tweetsInDateRange)
            {
                yield return tweet;
            }
        }
    }
}
