namespace SportsStore.Web.Models
{
    using System.Collections.Generic;
    using Domain.Models;

    public class ProductsListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}