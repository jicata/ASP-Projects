using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Web.Controllers
{
    using Domain.Abstract;
    using Models;

    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 4;
        // GET: Product
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public ViewResult List(string category, int page =1)
        {
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products =
                    this.repository.Products.OrderBy(p => p.ProductID)
                        .Where(p=> category == null || p.Category == category)
                        .Skip((page - 1)*this.PageSize)
                        .Take(this.PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = this.PageSize,
                    TotalItems = category == null ? this.repository.Products.Count() : this.repository.Products.Count(p => p.Category == category)
                },
               CurrentCategory = category
            };
            return this.View(model);
        }
    }
}