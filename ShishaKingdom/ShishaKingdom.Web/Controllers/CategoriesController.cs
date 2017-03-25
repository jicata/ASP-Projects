using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShishaKingdom.Web.Controllers
{
    using System.Collections;
    using System.Web.Mvc;
    using AutoMapper;
    using Base;
    using Data.Contracts;
    using Models;
    using Services;
    using ViewModels.Categories;
    using ViewModels.Products;

    [RoutePrefix("categories")]
    public class CategoriesController : BaseController
    {
        private CategoriesService service;
        public CategoriesController(IShishaKingdomData data) 
            : base(data)
        {
            this.service = new CategoriesService(data);
        }

        [Route("all")]
        public ActionResult All()
        {

            var cats = this.service.GetAllCategories().ToList();
            var catsVms =
                Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(cats);
            return this.View(catsVms);
        }

        [Route("add")]
        public ActionResult Add()
        {
            return this.View();
        }
        [Route("add")]
        [HttpPost]
        public ActionResult Add(AddCategoryViewModel adcvm)
        {
            try
            {
                var category = Mapper.Map<Category>(adcvm);
                this.service.AddNewCategory(category);
                return this.Redirect("all");
            }
            catch (Exception e)
            {
                return this.View(adcvm);
            }
        }

        [Route("category")]
        public ActionResult Category(int id)
        {
            var category = this.service.FindCategoryById(id);
            var categoryVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(category.Products.ToList());
            this.ViewBag.CategoryName = category.Name;
            return this.View(categoryVm);
        }


        [Route("edit")]
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cat = Mapper.Map<CategoryViewModel>(this.service.GetCategoryById(id));
            return this.View(cat);
        }

        [Route("edit")]
        [HttpPost]
        public ActionResult Edit(int id,CategoryViewModel cvm)
        {
            var editedCategory = Mapper.Map<Category>(cvm);
            this.service.UpdateCategeroy(editedCategory);
            this.TempData["success"] = "Успешно променена категория!";
            return this.Redirect("All");
        }
    }
}