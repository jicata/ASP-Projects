namespace ShishaKingdom.Web.Controllers
{
    using System.Web.Mvc;
    using Base;
    using Data.Contracts;

    [RoutePrefix("products")]
    public class ProductsController : BaseController
    {
        public ProductsController(IShishaKingdomData data) : base(data)
        {
        }

        [Route("add")]
        public ActionResult AddProduct()
        {
            return this.View();
        }
    }
}