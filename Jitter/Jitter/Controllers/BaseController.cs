using System.Web.Mvc;

namespace Jitter.Controllers
{
    using Data;
    using Data.Contracts;

    public class BaseController : Controller
    {
        protected IJitterData data;

        public BaseController(IJitterData data)
        {
            this.data = data;
        }
    }
}