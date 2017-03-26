namespace ShishaKingdom.Web.ViewModels.Categories
{
    using System.Collections.Generic;
    using Products;

    public class CategoryViewModel
    {
        public CategoryViewModel()
        {
            this.ProductViewModels = new HashSet<ProductViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int ProductsCount { get; set; }

        public virtual ICollection<ProductViewModel> ProductViewModels { get; set; }
        
    }
}