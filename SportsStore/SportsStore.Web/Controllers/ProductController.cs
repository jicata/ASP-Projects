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

        public ViewResult List(int page =1)
        {
            ProductsListViewModel model = new ProductsListViewModel()
            {
                Products =
                    this.repository.Products.OrderBy(p => p.ProductID)
                        .Skip((page - 1)*this.PageSize)
                        .Take(this.PageSize),
                PagingInfo = new PagingInfo()
                {
                    CurrentPage = page,
                    ItemsPerPage = this.PageSize,
                    TotalItems = this.repository.Products.Count()
                }
            };
            return this.View(model);
        }
    }
}