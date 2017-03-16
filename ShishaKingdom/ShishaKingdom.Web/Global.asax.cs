﻿namespace ShishaKingdom.Web
{
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AutoMapper;
    using Models;
    using ViewModels.Categories;

    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            LoadMappings();
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        private static void LoadMappings()
        {
            Mapper.Initialize(cfg => 
            {
                cfg.CreateMap<Category, CategoryViewModel>();
                cfg.CreateMap<AddCategoryViewModel, Category>();
            });
        }
    }
}
