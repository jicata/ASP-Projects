namespace ShishaKingdom.Web.Services
{
    using Data.Contracts;
    using Models;

    public class WishlistService : Service
    {
        public WishlistService(IShishaKingdomData data) : base(data)
        {
        }

        public User GetUserById(string userId)
        {
           return this.data.Context.Users.Find(userId);
        }

        public Product GetProductById(int id)
        {
            return this.data.Products.GetById(id);
        }

        public void AddProductToWishList(User user, Product product)
        {
            user.WishList.Products.Add(product);
            this.data.SaveChanges();
        }

        public void CheckoutWishList(string id)
        {
            var wishlist = this.data.Context.WishLists.Find(id);
            wishlist.IsCheckedOut = true;
            this.data.SaveChanges();
        }
    }
}