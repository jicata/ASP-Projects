namespace ShishaKingdom.Web.ViewModels.Categories
{
    using System.Collections.Generic;
    using Products;

    public class EditCategoryViewModel
    {
        public EditCategoryViewModel()
        {
            this.ProductViewModels = new List<ProductViewModel>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        public virtual ICollection<ProductViewModel> ProductViewModels { get; set; }
    }
}