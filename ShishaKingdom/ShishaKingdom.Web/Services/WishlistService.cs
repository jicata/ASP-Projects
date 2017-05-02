namespace ShishaKingdom.Web.Services
{
    using System;
    using Data.Contracts;
    using Models;
    using Models.Enums;

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
            var order = new Order()
            {
                MadeOn = DateTime.Now,
                Status = Status.Pending,
                Customer = wishlist.Customer,
                Products = wishlist.Products
            };
            this.data.Orders.InsertOrUpdate(order);
            wishlist.Products.Clear();
            this.data.SaveChanges();
        }

        public void RemoveProductFromWishList(WishList wishlist, int id)
        {
            var product = this.GetProductById(id);
            wishlist.Products.Remove(product);
            this.data.SaveChanges();
        }
    }
}