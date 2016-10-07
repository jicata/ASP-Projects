namespace JicaTweet.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Migrations;
    using Models;

    public class JicaTweetDbContext : IdentityDbContext<ApplicationUser>
    {

        public JicaTweetDbContext() : base("DefaultConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<JicaTweetDbContext, Configuration>());
        }
        public virtual IDbSet<Tweet> Tweets { get; set; }

        public DbContext Context => this;

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public static JicaTweetDbContext Create()
        {
            return new JicaTweetDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
