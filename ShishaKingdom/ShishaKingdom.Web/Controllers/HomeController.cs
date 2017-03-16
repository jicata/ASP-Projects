namespace ShishaKingdom.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Base;
    using Data;
    using Data.Contracts;

    public class HomeController : BaseController
    {       

        public HomeController(IShishaKingdomData data) 
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "За нас.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}