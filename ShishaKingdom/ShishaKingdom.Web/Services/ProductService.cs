namespace ShishaKingdom.Web.Services
{
    using System;
    using System.Collections.Generic;
    using Contracts;
    using Data.Contracts;
    using Models;
    using ViewModels.ProductViewModels;

    public class ProductService : Service,IProductService
    {
        public ProductService(IShishaKingdomData data) 
            : base(data)
        {
        }

        public IEnumerable<Product> GetAllProducts()
        {
            return this.Data.Products.GetAll();
        }

        public Product CreateProduct(ProductViewModel jvm)
        {
            var userId = base.GetCurrentUser();
            Product Product = new Product()
            {
            };
            return Product;
        }

    }
}
