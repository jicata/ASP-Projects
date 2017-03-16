﻿namespace ShishaKingdom.Web.Services
{
    using System.Collections.Generic;
    using Base;
    using Data.Contracts;
    using Models;

    public class CategoriesService : Service, ICategoriesService
    {
        public CategoriesService(IShishaKingdomData data) 
            : base(data)
        {
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return this.data.Categories.GetAll();
        }

        public void AddNewCategory(Category category)
        {
            this.data.Categories.InsertOrUpdate(category);
            this.data.SaveChanges();
        }
    }
}