using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace APIAuth.Models
{
    public class DbInit : DropCreateDatabaseIfModelChanges<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            List<Category> categories = new List<Category>()
            {
                new Category(){ CategoryName= "Category 1" },
                new Category(){ CategoryName= "Category 2" },
            };
            context.Categories.AddRange(categories);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}