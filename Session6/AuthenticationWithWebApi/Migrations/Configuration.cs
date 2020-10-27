namespace AuthenticationWithWebApi.Migrations
{
    using AuthenticationWithWebApi.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AuthenticationWithWebApi.Models.CompanyContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AuthenticationWithWebApi.Models.CompanyContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){Name="Category 1"},
                new Category(){Name="Category 2"},
                new Category(){Name="Category 3"}
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
        }
    }
}
