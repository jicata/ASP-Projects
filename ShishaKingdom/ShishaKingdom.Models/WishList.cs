namespace ShishaKingdom.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WishList
    {
        [Key,ForeignKey("Customer")]
        public string Id { get; set; }


        public virtual User Customer { get; set; }

        public virtual ICollection<Product> Products { get; set; }
        
    }
}
