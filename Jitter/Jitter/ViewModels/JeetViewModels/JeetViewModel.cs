namespace Jitter.ViewModels.JeetViewModels
{
    using System.ComponentModel;


    public class JeetViewModel
    {
        public int Id { get; set; }
        public string Author { get; set; }

        public string Content { get; set; }
            
        [DisplayName("Posted on")]
        public string PostedOn { get; set; }
    }
}