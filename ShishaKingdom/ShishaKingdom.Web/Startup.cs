using Microsoft.Owin;
using ShishaKingdom.Web;

[assembly: OwinStartup(typeof(Startup))]
namespace ShishaKingdom.Web
{
    using Owin;

    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            this.ConfigureAuth(app);
        }
    }
}
