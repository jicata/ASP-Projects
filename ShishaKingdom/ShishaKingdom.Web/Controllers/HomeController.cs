namespace ShishaKingdom.Web.Controllers
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;
    using AutoMapper;
    using Base;
    using Data;
    using Data.Contracts;
    using Models;
    using Services;
    using ViewModels.Categories;

    public class HomeController : BaseController
    {
        private CategoriesService service;

        public HomeController()
            :this(new ShishaKingdomData(new ShishaKingdomContext()))
        {

        }

        public HomeController(IShishaKingdomData data) 
            : base(data)
        {
            this.service = new CategoriesService(data);
        }

        public ActionResult Index()
        {
            var cats = this.service.GetAllCategories();
            var previewCats = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryPreviewViewModel>>(cats);
            var categoryPreviewViewModel = previewCats.FirstOrDefault();
            if (categoryPreviewViewModel != null) categoryPreviewViewModel.CarouselActive = "active";

            return this.View(previewCats);
        }

        public ActionResult About()
        {
            this.ViewBag.Message = "За нас.";

            return this.View();
        }

        public ActionResult Contact()
        {
            this.ViewBag.Message = "Your contact page.";

            return this.View();
        }
    }
}