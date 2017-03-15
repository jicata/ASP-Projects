namespace ShishaKingdom.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Contracts;

    public class BaseController : Controller
    {
        protected IShishaKingdomData data;

        public BaseController(IShishaKingdomData data)
        {
            this.data = data;
        }
    }
}