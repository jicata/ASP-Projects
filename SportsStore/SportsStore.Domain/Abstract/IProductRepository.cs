namespace SportsStore.Domain.Abstract
{
    using System.Linq;
    using Models;

    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}
