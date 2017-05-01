using System.Web.Mvc;

namespace ShishaKingdom.Web.Controllers
{
    using System;
    using System.Net;
    using AutoMapper;
    using Base;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Services;
    using ViewModels.Products;
    using ViewModels.WishlistViewModels;

    [Authorize]
    public class WishlistController : BaseController
    {

        private WishlistService wishlistService;
        public WishlistController(IShishaKingdomData data) : base(data)
        {
            this.wishlistService = new WishlistService(data);
        }

        public ActionResult Index(string returnUrl)
        {
            string userId = User.Identity.GetUserId();
            var user = this.wishlistService.GetUserById(userId);
            this.ViewBag.ReturnUrl = returnUrl;
            var wishlistViewModel = Mapper.Map<WishlistViewModel>(user.WishList);
            return View("Wishlist",wishlistViewModel);
        }

        [ActionName("Add")]
        public ActionResult AddConfirm(int id, string returnUrl)
        {
            var product = Mapper.Map<ProductViewModel>(this.wishlistService.GetProductById(id));
            this.ViewBag.ReturnUrl = returnUrl;
            return this.View(product);
        }

        [HttpPost]
        public ActionResult Add(int productId, string returnUrl)
        {
            var product = this.wishlistService.GetProductById(productId);
            if (product != null)
            {
                string userId = User.Identity.GetUserId();
                if (!string.IsNullOrEmpty(userId))
                {
                    var user = this.wishlistService.GetUserById(userId);
                    //this.wishlistService.AddProductToWishList(user, product);
                    string decodedUrl = WebUtility.UrlDecode(returnUrl);
                    if (this.Request.IsLocal)
                    {
                        return this.Redirect(returnUrl);
                    }
                       
                }
            }
            return this.RedirectToAction("All", "Products", new {area=""});
        }

        public ActionResult RedirectToLocal(string returnUrl)
        {
            if (this.Url.IsLocalUrl(returnUrl))
            {
                return this.Redirect(returnUrl);
            }
            return this.RedirectToAction("Index", "Home");
        }

    }
}