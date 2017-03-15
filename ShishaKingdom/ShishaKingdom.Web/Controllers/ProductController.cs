namespace ShishaKingdom.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data;
    using Data.Contracts;
    using Models;
    using Services;
    using Services.Contracts;
    using ViewModels.ProductViewModels;

    [Authorize]
    [RoutePrefix("Products")]
    public class ProductController : BaseController
    {
        private readonly IProductService service;

        public ProductController()
            : this(new ShishaKingdomData(new ShishaKingdomContext()))
        {
            
        }
        public ProductController(IShishaKingdomData data)
            : base(data)
        {
            this.service = new ProductService(data);
        }

        [AllowAnonymous]
        [Route("all")]
        public ActionResult All()
        {
            var ProductViewModels =
                Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>
                    (this.service.GetAllProducts()).ToList();
            var item = ProductViewModels[0];
            return this.View(ProductViewModels);
        }

        [Route("new")]
        public ActionResult New()
        {
            return this.View();
        }

        [Route("new")]
        [HttpPost]
        public ActionResult New(ProductViewModel jvm)
        {

            var Product = this.service.CreateProduct(jvm);
            this.data.Products.InsertOrUpdate(Product);
            this.data.SaveChanges();
            return this.RedirectToAction("All");
        }

        public ActionResult BestProduct()
        {
            var bestProduct = Mapper.Map<ProductViewModel>(this.data.Products.GetAll().FirstOrDefault());
            return this.PartialView(bestProduct);
        }

        [Route("Error")]
        public ActionResult Error()
        {
            this.Response.StatusCode = 404;
            return this.View();
        }
    }
}