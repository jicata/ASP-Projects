namespace ShishaKingdom.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Data.Contracts;
    using Models;
    using Services;
    using ViewModels.Categories;
    using Web.Controllers.Base;

    
    public class CategoriesController : BaseController
    {
        private CategoriesService service;

        public CategoriesController(IShishaKingdomData data) : base(data)
        {
            this.service = new CategoriesService(data);
        }

        public ActionResult All()
        {

            var cats = this.service.GetAllCategories().ToList();
            var catsVms =
                Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(cats);
            return this.View(catsVms);
        }


        public ActionResult Add()
        {
            return this.View();
        }
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
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var cat = Mapper.Map<CategoryViewModel>(this.service.GetCategoryById(id));
            return this.View(cat);
        }

        [HttpPost]
        public ActionResult Edit(int id, CategoryViewModel cvm)
        {
            var editedCategory = Mapper.Map<Category>(cvm);
            this.service.UpdateCategeroy(editedCategory);
            this.TempData["success"] = "Успешно променена категория!";
            return this.Redirect("All");
        }
    }
}