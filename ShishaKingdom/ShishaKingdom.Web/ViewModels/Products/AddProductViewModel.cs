namespace ShishaKingdom.Web.ViewModels.Products
{
    using Models.Enums;

    public class AddProductViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Availability Availability { get; set; }

        public string ImageUrl { get; set; }
    }
}