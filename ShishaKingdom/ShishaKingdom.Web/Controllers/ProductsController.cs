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
            var productsFromDb = this.service.GetAllProducts();
            var products = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productsFromDb);
            return this.View(products);
        }

        [Route("allInCategory")]
        public ActionResult AllInCategory(string name)
        {
            var productsFromCat = this.service.ProductsFromCategory(name);
            var products = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productsFromCat);
            this.ViewBag.CategoryName = name;
            return this.View(products);
        }

        [Route("addProduct")]
        public ActionResult AddProduct()
        {

            return this.View();
        }

        [Route("addProduct")]
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