namespace Jitter.Models
{
    using System.ComponentModel.DataAnnotations.Schema;
    using Data.IdentityModels;

    public class Message
    {
        public int Id { get; set; }

        [ForeignKey("Sender")]
        public string SenderId { get; set; }

        [ForeignKey("Reciever")]
        public string RecieverId { get; set; }

        public virtual User Sender { get; set; }

        public virtual User Reciever { get; set; }

        public string Content { get; set; }
        
    }
}
