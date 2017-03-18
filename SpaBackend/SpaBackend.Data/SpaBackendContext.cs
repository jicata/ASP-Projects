using Microsoft.AspNet.Identity.EntityFramework;

namespace SpaBackend.Models
{
    using System.Data.Entity;

    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.

    public class SpaBackendContext : IdentityDbContext<User>
    {
        public SpaBackendContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static SpaBackendContext Create()
        {
            return new SpaBackendContext();
        }

        public DbSet<Phone> Phones { get; set; }
    }
}