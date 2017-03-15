namespace ShishaKingdom.Web.ViewModels.ProductViewModels
{
    using System.ComponentModel;

    public class NewProductViewModel
    {
        [DisplayName("What's on your mind?")]
        public string Content { get; set; }
    }
}