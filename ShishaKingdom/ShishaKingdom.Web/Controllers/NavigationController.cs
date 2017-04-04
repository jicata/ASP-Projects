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
    using ViewModels.Categories;

    public class NavigationController : BaseController
    {
        private CategoriesService service;

        public NavigationController()
            :this(new ShishaKingdomData(new ShishaKingdomContext()))
        {

        }

        public NavigationController(IShishaKingdomData data) : base(data)
        {
            this.service = new CategoriesService(data);
        }

        public ActionResult SideMenu()
        {
            var cats = this.service.GetAllCategories().ToList();
            var partialCats = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryViewModel>>(cats);
            return this.PartialView("_SideMenu",partialCats);
        }

        public ActionResult Category()
        {
            return this.View();
        }
    }
}