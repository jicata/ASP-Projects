namespace Jitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity;

    public  class Jeet
    {
        public Jeet()
        {
            this.Favoriters = new HashSet<User>();
            this.Rejeeters = new HashSet<User>();
        }
        public int Id { get; set; }

        [ForeignKey("Author")]
        [Column("AuthorId")]
        public string UserId { get; set; }

        [StringLength(160)]
        [MinLength(1)]
        public string Content { get; set; }

        public DateTime? PostedOn { get; set; }

        [InverseProperty("FavoriteJeets")]
        [DisplayName("Favorited By")]
        public virtual ICollection<User> Favoriters { get; set; }

        [InverseProperty("Rejeets")]
        [DisplayName("Rejeeted by")]
        public virtual ICollection<User> Rejeeters { get; set; }


        public virtual User Author { get; set; }
        

        [ScaffoldColumn(false)]
        public int Reported { get; set; }
        
    }
}
