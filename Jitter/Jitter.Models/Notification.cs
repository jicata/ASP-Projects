namespace Jitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Notification
    {
        public int Id { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public string Content { get; set; }

        public DateTime? Date { get; set; }

        public virtual User User { get; set; }
        
    }
}
