namespace ShishaKingdom.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data;

    public class HomeController : Controller
    {
        ShishaKingdomData data = new ShishaKingdomData(new ShishaKingdomContext());
        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "Your application description page.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}