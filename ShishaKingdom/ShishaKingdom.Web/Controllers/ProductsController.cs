namespace ShishaKingdom.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using Base;
    using Data.Contracts;
    using Models;
    using Services;
    using ViewModels.Products;

    [RoutePrefix("products")]
    public class ProductsController : BaseController
    {
        private ProductsService service;
        public ProductsController(IShishaKingdomData data) : base(data)
        {
            this.service = new ProductsService(data);
        }

        [Route("all")]
        public ActionResult All()
        {
            var products = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(this.service.GetAllProducts());
            return this.View(products);
        }

        [Route("add")]
        public ActionResult AddProduct()
        {

            return this.View();
        }

        [Route("add")]
        [HttpPost]
        public ActionResult AddProduct(AddProductViewModel apvm)
        {
            var product = Mapper.Map<Product>(apvm);
            this.service.AddProduct(product);
            return this.Redirect("All");
        }

        [Route("remove")]
        public ActionResult Remove(int id)
        {
            this.service.RemoveProduct(id);
            return this.Redirect("All");
        }
    }
}