namespace JicaTweet.Data
{
    using Repositories;
    using Repositories.Contracts;

    public class JicaTweetData :IJicaTweetData
    {
        private readonly JicaTweetDbContext context;

        public JicaTweetData()
            :this(new JicaTweetDbContext())
        {
            
        }

        public JicaTweetData(JicaTweetDbContext context)
        {
            this.context = context;
        }

        public JicaTweetDbContext Context
        {
            get { return this.context; }
        }

        public IApplicationUserRepository Users =>new UserRepository(this.context);

        public ITweetRepository Tweets =>new TweetRepository(this.context);

        public void Dispose()
        {
            this.Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                this.context?.Dispose();
            }
        }

    }
}
