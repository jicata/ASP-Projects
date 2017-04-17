namespace ShishaKingdom.Models
{
    using System;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations.Schema;
    using Enums;

    public class Product
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }


        public Availability Availability { get; set; }

        public virtual Category Category { get; set; }
        
        public string ImageUrl { get; set; }
    }
}
