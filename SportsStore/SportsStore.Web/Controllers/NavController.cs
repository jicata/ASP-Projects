using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SportsStore.Web.Controllers
{
    using Domain.Abstract;

    public class NavController : Controller
    {
        private IProductRepository repository;

        public NavController(IProductRepository repo)
        {
            this.repository = repo;
        }
        // GET: Nav
        public PartialViewResult Menu(string category=null)
        {
            ViewBag.SelectedCategory = category;
            IEnumerable<string> cats = this.repository.Products.Select(p => p.Category).Distinct().OrderBy(x => x);
            return this.PartialView(cats);
        }
    }
}