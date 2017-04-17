using ShishaKingdom.Data;

namespace ShishaKingdom.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
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

        public ProductsController()
            : this(new ShishaKingdomData(new ShishaKingdomContext()))
        {

        }

        public ProductsController(IShishaKingdomData data) : base(data)
        {
            this.service = new ProductsService(data);
        }

        [Route("all")]
        public ActionResult All()
        {
            var productsFromDb = this.service.GetAllProducts();
            var products = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productsFromDb);
            return this.View(products);
        }

        [Route("details")]
        public ActionResult Details(int id)
        {
            var product = Mapper.Map<ProductViewModel>(this.service.FindProductById(id));
            return this.View(product);
        }
    }
}