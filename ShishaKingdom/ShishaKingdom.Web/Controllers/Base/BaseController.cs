namespace ShishaKingdom.Web.Controllers.Base
{
    using System.Web.Mvc;
    using Data.Contracts;
    using Services;

    public abstract class BaseController : Controller
    {
        private IShishaKingdomData data;
        protected BaseController(IShishaKingdomData data)
        {
            this.data = data;
        }
        
    }
}