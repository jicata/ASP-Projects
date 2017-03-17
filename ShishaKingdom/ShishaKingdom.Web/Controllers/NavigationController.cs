namespace ShishaKingdom.Web.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;
    using AutoMapper;
    using Base;
    using Data.Contracts;
    using Models;
    using Services;
    using ViewModels.Categories;

    public class NavigationController : BaseController
    {
        private CategoriesService service;
        public NavigationController(IShishaKingdomData data) : base(data)
        {
            this.service = new CategoriesService(data);
        }

        public ActionResult SideMenu()
        {
            var cats = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(this.service.GetAllCategories());
            return this.PartialView(cats);
        }

        public ActionResult Category()
        {
            return this.View();
        }
    }
}