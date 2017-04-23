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


    [RoutePrefix("Products")]
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
        [Route("Products")]
        public ActionResult Products(int? categoryId, string search)
        {
            IEnumerable<Product> products = categoryId != null
                ? this.service.GetAllProducts(categoryId.Value)
                : this.service.GetAllProducts();
           
            if (search != null)
            {
                products = products.Where(p => p.Name.Contains(search));
            }
            var productVierwModels = Mapper.Map<IEnumerable<ProductViewModel>>(products);
            return this.PartialView("_ProductPartial",productVierwModels);
        }
        [Route("Details")]
        public ActionResult Details(int id)
        {
            var product = Mapper.Map<ProductViewModel>(this.service.FindProductById(id));
            return this.View(product);
        }
        [Route("All")]
        public ActionResult All(int? categoryId,string search= null)
        {
            var productsFromDb = categoryId == null
                ? this.service.GetAllProducts()
                : this.service.GetAllProducts().Where(p => p.Category.Id == categoryId.Value);

            this.ViewBag.Search = search;
            var products = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productsFromDb);
            return this.View(products);
        }
    }
}