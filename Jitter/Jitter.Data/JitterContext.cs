namespace Jitter.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class JitterContext : IdentityDbContext<User>, IJitterContext
    {
        public JitterContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static JitterContext Create()
        {
            return new JitterContext();
        }

        public virtual DbSet<Jeet> Jeets { get; set; }
        public DbContext DbContext => this;
        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}