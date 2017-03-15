namespace ShishaKingdom.Web.Services
{
    using System.Web;
    using Contracts;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;

    public class Service : IService
    {
        public Service(IShishaKingdomData data)
        {
            this.Data = data;
        }

        public IShishaKingdomData Data { get; private set; }
        public string GetCurrentUser()
        {
            return HttpContext
                .Current
                .User
                .Identity
                .GetUserId();
        }
    }
}
