namespace ShishaKingdom.Web.Controllers
{
    using System.Web.Mvc;

    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return this.View();
        }
    }
}