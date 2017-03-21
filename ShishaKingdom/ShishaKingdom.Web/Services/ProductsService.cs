namespace ShishaKingdom.Web.Services
{
    using System.Collections.Generic;
    using Data.Contracts;
    using Models;

    public class ProductsService : Service
    {
        public ProductsService(IShishaKingdomData data) : base(data)
        {
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.data.Products.GetAll();
        }

        public void AddProduct(Product product)
        {
            this.data.Products.InsertOrUpdate(product);
            this.data.SaveChanges();
        }
    }
}