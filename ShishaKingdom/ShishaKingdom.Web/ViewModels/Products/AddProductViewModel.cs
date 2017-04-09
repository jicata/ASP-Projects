namespace ShishaKingdom.Web.ViewModels.Products
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Models.Enums;

    public class AddProductViewModel
    {
        [Display(Name = "Име")]
        public string Name { get; set; }

        [Display(Name="Описание")]
        public string Description { get; set; }

        [Display(Name="Цена")]
        public decimal Price { get; set; }

        [Display(Name="Наличност")]
        public Availability Availability { get; set; }

        [Display(Name="Изображение")]
        public string ImageUrl { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }

        public int CategoryId { get; set; }
    }
}