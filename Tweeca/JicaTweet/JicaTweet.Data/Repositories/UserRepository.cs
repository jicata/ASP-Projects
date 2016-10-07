namespace JicaTweet.Data.Repositories
{
    using System.Linq;
    using Base;
    using Contracts;
    using JicaTweet.Contracts;
    using Models;

    public class UserRepository: GenericRepository<ApplicationUser>, IApplicationUserRepository
    {
        public UserRepository(JicaTweetDbContext context) : base(context)
        {
        }

        public ApplicationUser GetByUsername(string username)
        {
            //var user = this.Context.Users.FirstOrDefault(u => u.UserName == username);
            //return user;
            return null;
        }

        public ApplicationUser GetById(int id)
        {
            //var user = this.Context.Users.FirstOrDefault(u => u.Id == id.ToString());
            //return user;
            return null;
        }
    }
}
