namespace ShishaKingdom.Web.Services
{
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Contracts;
    using Models;
    using ViewModels.Products;

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

        public void RemoveProduct(Product product)
        {
            this.data.Products.Delete(product);
            this.data.SaveChanges();
        }

        public IEnumerable<Product> ProductsFromCategory(string name)
        {
            return this.data.Categories.GetAll().FirstOrDefault(c=>c.Name == name).Products;
        }

        public void AddProductToCategory(AddProductViewModel apvm)
        {

            var product = Mapper.Map<Product>(apvm);
            this.FindCategoryByName(apvm.CategoryName).Products.Add(product);
            this.data.SaveChanges();
        }

        public Category FindCategoryByName(string apvmName)
        {
            return this.data.Categories.FindByPredicate(c => c.Name == apvmName);
        }

        public Product FindProductById(int id)
        {
            return this.data.Products.GetById(id);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return this.data.Categories.GetAll();
        }
    }
}