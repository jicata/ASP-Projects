namespace Jitter.Data
{
    using System.Data.Entity;
    using Contracts;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    public class JitterContext : IdentityDbContext<User>, IJitterContext
    {
        public JitterContext()
            : base("Jitter")//, throwIfV1Schema: false)
        {
        }

        public static JitterContext Create()
        {
            return new JitterContext();
        }

        public virtual DbSet<Jeet> Jeets { get; set; }
        public DbContext DbContext => this;
        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasMany(u => u.Following).WithMany().Map(u =>
            {
                u.MapLeftKey("UserId");
                u.MapRightKey("FollowingId");
                u.ToTable("UserFollowing");
            });

            modelBuilder.Entity<User>().HasMany(u => u.FollowedBy).WithMany().Map(u =>
            {
                u.MapLeftKey("UserId");
                u.MapRightKey("FollowerId");
                u.ToTable("UserFollowedBy");
            });

            modelBuilder.Entity<User>()
              .HasMany<Jeet>(u=>u.FavoriteJeets)
              .WithMany(j=>j.Favoriters)
              .Map(cs =>
              {
                  cs.MapLeftKey("UserFavoriterId");
                  cs.MapRightKey("JeetFavoritedId");
                  cs.ToTable("UsersFavoriteJeets");
              });
            modelBuilder.Entity<User>()
             .HasMany<Jeet>(u => u.Rejeets)
             .WithMany(j => j.Rejeeters)
             .Map(cs =>
             {
                 cs.MapLeftKey("UserRejeeterId");
                 cs.MapRightKey("JeetRejeetedId");
                 cs.ToTable("UsersRejeetedJeets");
             });

            base.OnModelCreating(modelBuilder);
        }
    }
}