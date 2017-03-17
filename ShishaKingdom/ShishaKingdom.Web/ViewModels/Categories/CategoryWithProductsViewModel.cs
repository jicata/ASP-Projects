namespace ShishaKingdom.Web.ViewModels.Categories
{
    using System;
    using System.Collections.Generic;
    using Products;

    public class CategoryWithProductsViewModel
    {
        public CategoryWithProductsViewModel()
        {
            this.Products = new HashSet<ProductViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }
        
    }
}