namespace ShishaKingdom.Web.ViewModels.WishlistViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    using Models;
    using Products;

    public class WishlistViewModel
    {
        public WishlistViewModel()
        {
            this.Products = new HashSet<ProductViewModel>();
            this.TotalPrice = CalculateTotalPrice();
        }       

        public string Id { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual ICollection<ProductViewModel> Products { get; set; }

        private decimal CalculateTotalPrice()
        {
            return this.Products.Sum(p => p.Price);
        }
    }
}