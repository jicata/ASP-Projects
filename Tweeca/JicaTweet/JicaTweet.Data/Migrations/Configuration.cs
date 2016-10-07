namespace JicaTweet.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<JicaTweet.Data.JicaTweetDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(JicaTweet.Data.JicaTweetDbContext context)
        {
            if (!context.Tweets.Any())
            {
                List<Tweet> tweets = new List<Tweet>()
                    {
                        new Tweet("Gosho", "Stana Vurgala"),
                        new Tweet("Pesho", "Aide KamelIqqqqQ")
                    };

                context.Tweets.Add(tweets[0]);
                context.Tweets.Add(tweets[1]);
                context.SaveChanges();
            }

        }
    }
}
