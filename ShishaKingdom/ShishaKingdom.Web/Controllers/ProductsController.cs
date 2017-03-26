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

            //[Route("allInCategory")]
            //public ActionResult AllInCategory(string name)
            //{
            //    var productsFromCat = this.service.ProductsFromCategory(name);
            //    var products = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(productsFromCat);
            //    this.ViewBag.CategoryName = name;
            //    return this.View(products);
            //}

            [Route("addProduct")]
            public ActionResult AddProduct(string category)
            {

                this.ViewBag.CategoryName = category;
                return this.View();
            }

            [Route("addProduct")]
            [HttpPost]
            public ActionResult AddProduct(AddProductViewModel apvm)
            {
                this.service.AddProductToCategory(apvm);
                return this.RedirectToAction("Category", "Categories",
                    new {id = this.service.FindCategoryByName(apvm.CategoryName).Id});
            }

            [Route("remove")]
            public ActionResult Remove(int id)
            {
                var product = this.service.FindProductById(id);
                int catId = product.Category.Id;
                this.service.RemoveProduct(product);
                return this.RedirectToAction("Edit", "Categories", new {id = catId});
            }
        }
    }