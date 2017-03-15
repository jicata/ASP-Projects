namespace ShishaKingdom.Web.Services.Contracts
{
    using System.Collections.Generic;
    using Models;
    using ViewModels.ProductViewModels;

    public interface IProductService : IService
    {
        IEnumerable<Product> GetAllProducts();
        Product CreateProduct(ProductViewModel jvm);
    }
}
