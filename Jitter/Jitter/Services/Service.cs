namespace Jitter.Services
{
    using System.Web;
    using Contracts;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Models;

    public class Service : IService
    {
        public Service(IJitterData data)
        {
            this.Data = data;
        }

        public IJitterData Data { get; private set; }
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
