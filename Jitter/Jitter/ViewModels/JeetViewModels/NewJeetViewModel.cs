namespace Jitter.ViewModels.JeetViewModels
{
    using System.ComponentModel;

    public class NewJeetViewModel
    {
        [DisplayName("What's on your mind?")]
        public string Content { get; set; }
    }
}