using System.Web.Mvc;

namespace ShishaKingdom.Web.Controllers
{
    using AutoMapper;
    using Base;
    using Data.Contracts;
    using Microsoft.AspNet.Identity;
    using Services;
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