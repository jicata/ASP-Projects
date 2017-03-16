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
            var catsVms =
                Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(this.service.GetAllCategories());
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

    }
}