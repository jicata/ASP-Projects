namespace ShishaKingdom.Web.ViewModels.ManageViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class AddPhoneNumberViewModel
    {
        [Required]
        [Phone]
        [Display(Name = "Phone Number")]
        public string Number { get; set; }
    }
}