namespace Jitter.Data
{
    using Contracts;
    using IdentityModels;
    using Models;
    using Repositories;

    public  class JitterData : IJitterData
    {
        private readonly IJitterContext context;

        public JitterData(IJitterContext context)
        {
            this.context = context;
        }
        public IRepository<User> Users=> new Repository<User>(this.context);
        public IRepository<Jeet> Jeets => new Repository<Jeet>(this.context);

        public IJitterContext Context => this.context;
        public int SaveChanges()
        {
            return this.Context.SaveChanges();
        }

     
    }
}
