namespace ShishaKingdom.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
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

        public void RemoveProduct(int id)
        {
            var product = this.data.Products.GetById(id);
            this.data.Products.Delete(product);
            this.data.SaveChanges();
        }

        public IEnumerable<Product> ProductsFromCategory(string name)
        {
            return this.data.Categories.GetAll().FirstOrDefault(c=>c.Name == name).Products;
        }

    }
}