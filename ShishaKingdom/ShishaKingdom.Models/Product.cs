namespace ShishaKingdom.Models
{
    using Enum;

    public class Product
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }

        public Availability Availability { get; set; }

        public virtual Category Category { get; set; }
        
    }
}
