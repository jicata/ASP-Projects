namespace ShishaKingdom.Models
{
    using System;
    using System.Collections.Generic;
    using Enums;

    public class Order
    {

        public Order()
        {
            this.Products = new HashSet<Product>();
        }
        public int Id { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual User Customer { get; set; }

        public DateTime? MadeOn { get; set; }

        public Status Status { get; set; }
    }
}
