using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShishaKingdom.Web.Controllers
{
    using Base;
    using Data.Contracts;
    using Services;

    public class WishlistController : BaseController
    {

        private WishlistService wishlistService;
        public WishlistController(IShishaKingdomData data) : base(data)
        {
            this.wishlistService = new WishlistService(data);
        }

        public ActionResult Index()
        {
            return View("Wishlist");
        }
    }
}