namespace ShishaKingdom.Web.ViewModels.Categories
{
    using System.ComponentModel.DataAnnotations;

    public class AddCategoryViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = (4))]
        public string Name { get; set; }
    }
}