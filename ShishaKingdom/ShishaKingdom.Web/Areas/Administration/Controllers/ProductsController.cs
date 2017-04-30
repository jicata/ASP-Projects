using System.Web.Mvc;

namespace ShishaKingdom.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using AutoMapper;
    using Data;
    using Data.Contracts;
    using Services;
    using ViewModels.Products;
    using Web.Controllers.Base;

    [Authorize(Roles = "Admin")]
    [RoutePrefix("Products")]
    public class ProductsController : BaseController
    {
        private ProductsService service;

        public ProductsController()
            : this(new ShishaKingdomData(new ShishaKingdomContext()))
        {

        }

        public ProductsController(IShishaKingdomData data) 
            : base(data)
        {
            this.service = new ProductsService(data);
        }

        

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

        [HttpPost]
        public ActionResult AddProduct(AddProductViewModel apvm)
        {
            this.service.AddProductToCategory(apvm);
            return this.RedirectToAction("Category", "Categories",
                new { id = apvm.CategoryId, area="" });
        }

        [HttpGet]
        [ActionName("Remove")]
        public ViewResult RemoveConfirmation(int id)
        {
            var product = Mapper.Map<RemoveProductViewModel>(this.service.FindProductById(id));
            
            return this.View(product);
        }

        [HttpPost]
        public ActionResult Remove(int id)
        {
            var product = this.service.FindProductById(id);
            int catId = product.Category.Id;
            this.service.RemoveProductById(id);
            return this.RedirectToAction("All","Products", new {area=""});
        }

        public ActionResult Edit(int id, string returnUrl)
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
            this.ViewBag.ReturnUrl = returnUrl;
            return this.View(editProductViewModel);
        }
                       
        [HttpPost]
        public ActionResult Edit(EditProductViewModel epvm, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                this.service.EditProduct(epvm);
                return RedirectToAction("All","Products", new {area=""});
            }
            return this.View(epvm);
        }

    }
}