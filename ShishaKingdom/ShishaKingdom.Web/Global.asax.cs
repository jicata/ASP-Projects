namespace ShishaKingdom.Web
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;
    using AutoMapper;
    using Models;
    using Models.Enums;
    using ViewModels.Categories;
    using ViewModels.Products;

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
                cfg.CreateMap<Category, CategoryViewModel>()
                    .ForMember(dest => dest.ProductsCount, opts => opts.MapFrom(src => src.Products.Count))
                    .ForMember(dest=>dest.ProductViewModels, opts=>opts.MapFrom(src=>src.Products));
                cfg.CreateMap<Category, EditCategoryViewModel>()
                    .ForMember(dest => dest.ProductViewModels, opts => opts.MapFrom(src => src.Products));
                cfg.CreateMap<AddCategoryViewModel, Category>();
                cfg.CreateMap<Category, CategoryWithProductsViewModel>()
                    .ForMember(dest => dest.Products, opts => opts.MapFrom(src => src.Products));
                cfg.CreateMap<Product, ProductViewModel>()
                    .ForMember(dest => dest.Available,
                        opts => opts.MapFrom(src => src.Availability.ToString() == "Available"));
                cfg.CreateMap<CategoryViewModel, Category>();
                cfg.CreateMap<AddProductViewModel, Product>()
                    .ForMember(dest => dest.AvailableSince, opts => opts.MapFrom(src => DateTime.Now));
                cfg.CreateMap<Category, CategoryPreviewViewModel>();
                cfg.CreateMap<Product, EditProductViewModel>();
                cfg.CreateMap<EditProductViewModel, Product>();
            });
        }
    }
}
