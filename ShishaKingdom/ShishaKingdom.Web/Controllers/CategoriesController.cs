using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ShishaKingdom.Data;

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

        public CategoriesController()
            :this(new ShishaKingdomData(new ShishaKingdomContext()))
        {
            
        }

        public CategoriesController(IShishaKingdomData data) 
            : base(data)
        {
            this.service = new CategoriesService(data);
        }

    


        [Route("category")]
        [AllowAnonymous]
        public ActionResult Category(int id,string search=null)
        {
            var category = this.service.FindCategoryById(id);
            var categoryVm = Mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(category.Products.ToList());
            this.ViewBag.CategoryId = id;
            this.ViewBag.CategoryName = category.Name;
            this.ViewBag.Search = search;
            return this.View(categoryVm);
        }


        
    }
}