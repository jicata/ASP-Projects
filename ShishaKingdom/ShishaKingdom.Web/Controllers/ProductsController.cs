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

        [Route("addProduct")]
        public ActionResult AddProduct(int? categoryId)
        {

            var categories = this.service.GetAllCategories().Select(c => new SelectListItem()
            {
                Text = c.Name,
                Value = c.Id.ToString(),
                Selected = categoryId == c.Id

            });
            AddProductViewModel adpvm = new AddProductViewModel()
            {
                Categories = categories
            };
            return this.View(adpvm);
        }

        [Route("addProduct")]
        [HttpPost]
        public ActionResult AddProduct(AddProductViewModel apvm)
        {
            this.service.AddProductToCategory(apvm);
            return this.RedirectToAction("Category", "Categories",
                new { id = apvm.CategoryId });
        }

        [Route("remove")]
        public ActionResult Remove(int id)
        {
            var product = this.service.FindProductById(id);
            int catId = product.Category.Id;
            this.service.RemoveProductById(id);
            return this.RedirectToAction("Edit", "Categories", new { area="administration",id = catId });
        }

        [Route("edit")]
        public ActionResult Edit(int id)
        {
            var editProductViewModel = Mapper.Map<EditProductViewModel>(this.service.FindProductById(id));
            var categories = this.service.GetAllCategories();
            foreach (var category in categories)
            {
                var selectListItem = new SelectListItem()
                {
                    Value = category.Id.ToString(),
                    Text = category.Name,
                    Selected = editProductViewModel.CategoryId == category.Id
                };
                editProductViewModel.Categories.Add(selectListItem);
            }
            return this.View(editProductViewModel);
        }

        [Route("edit")]
        [HttpPost]
        public ActionResult Edit(EditProductViewModel epvm)
        {
            if (ModelState.IsValid)
            {
                this.service.EditProduct(epvm);
                return RedirectToAction("Category", "Categories", routeValues: new {id = epvm.CategoryId});
            }
            return this.View(epvm);
        }
    }
}