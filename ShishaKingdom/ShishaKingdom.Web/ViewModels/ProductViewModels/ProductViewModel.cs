namespace ShishaKingdom.Web.ViewModels.ProductViewModels
{
    using System.ComponentModel;

    public class ProductViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }

        public string Content { get; set; }
            
        [DisplayName("Posted on")]
        public string PostedOn { get; set; }
    }
}