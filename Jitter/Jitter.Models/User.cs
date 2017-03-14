namespace Jitter.Models
{
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Security.Claims;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class User : IdentityUser
    {

        public User()
        {
            this.FollowedBy = new HashSet<User>();
            this.Following = new HashSet<User>();
            this.Jeets= new HashSet<Jeet>();
            this.FavoriteJeets = new HashSet<Jeet>();
            this.Messages = new HashSet<Message>();
            this.Rejeets = new HashSet<Jeet>();
        }

        [DisplayName("Followed By")]
        public virtual ICollection<User> FollowedBy { get; set; }

        public virtual ICollection<User> Following { get; set; }

        public virtual ICollection<Jeet> Jeets { get; set; }

        [InverseProperty("Favoriters")]
        [DisplayName("Favorite Jeets")]
        public virtual ICollection<Jeet> FavoriteJeets { get; set; }

        [InverseProperty("Rejeeters")]
        public virtual ICollection<Jeet> Rejeets { get; set; }
        
        public virtual ICollection<Message> Messages { get; set; }
        

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }
}