﻿namespace ShishaKingdom.Models
{
    using System.Collections;
    using System.Collections.Generic;

    public class Category
    {
        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImgUrl { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        public virtual ICollection<Category> SubCategories { get; set; }
        
    }
}
