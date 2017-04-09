namespace ShishaKingdom.Web.ViewModels.Products
{
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;
    using Models.Enums;

    public class EditProductViewModel
    {
        public EditProductViewModel()
        {
            this.Categories = new List<SelectListItem>();
        }

        public string Name { get; set; }

        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }

        public Availability Availability { get; set; }

        public string ImageUrl { get; set; }

        public DateTime? AvailableSince { get; set; }

        public ICollection<SelectListItem> Categories { get; set; }

        public int CategoryId { get; set; }
    }
}