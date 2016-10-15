using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RazorTesting.Controllers
{
    using Models;

    public class HomeController : Controller
    {
        private Product myProduct = new Product()
        {
            ProductId = 1,
            Name = "Kayak",
            Description = "A boat for one person",
            Category = "Watersports",
            Price = 27M
        };
        // GET: Home
        public ActionResult Index()
        {
            return View(this.myProduct);
        }

        public ActionResult NameAndPrice()
        {
            return this.View(this.myProduct);
        }

        public ActionResult DemoExpression()
        {
            ViewBag.ProductCount = 1;
            ViewBag.ExpressShip = true;
            ViewBag.ApplyDiscount = false;
            ViewBag.Supplier = null;
            return this.View(this.myProduct);
        }
    }
}