namespace SpaBackend.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<SpaBackend.Models.SpaBackendContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(SpaBackend.Models.SpaBackendContext context)
        {
            var phone = new Phone();
            List<Phone> phones = new List<Phone>()
            {
                new Phone()
                {
                    Name = "Sasheto",
                    Price = 1,
                    ImageUrl = "http://i-cdn.phonearena.com/images/phones/42880-specs/Apple-iPhone-5c.jpg",
                    InStock = true
                },
                new Phone()
                {
                    Name = "E",
                    Price = 2,
                    ImageUrl = "http://i-cdn.phonearena.com/images/phones/42880-specs/Apple-iPhone-5c.jpg",
                    InStock = false
                },
                new Phone()
                {
                    Name = "Gei",
                    Price = 3,
                    ImageUrl = "http://i-cdn.phonearena.com/images/phones/42880-specs/Apple-iPhone-5c.jpg",
                    InStock = true
                },

            };


            context.Phones.AddRange(phones);
            context.SaveChanges();
        }
    }
}
