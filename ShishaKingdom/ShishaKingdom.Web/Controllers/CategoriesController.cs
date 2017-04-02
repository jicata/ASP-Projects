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
    [Authorize(Roles = "Admin")]
    public class CategoriesController : BaseController
    {
        private CategoriesService service;
        public CategoriesController(IShishaKingdomData data) 
            : base(data)
        {
            this.service = new CategoriesService(data);
        }

    


        [Route("category")]
        [AllowAnonymous]
        public ActionResult Category(int id)
        {
            var category = this.service.FindCategoryById(id);
            var categoryVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(category.Products.ToList());
            this.ViewBag.CategoryName = category.Name;
            return this.View(categoryVm);
        }


        
    }
}