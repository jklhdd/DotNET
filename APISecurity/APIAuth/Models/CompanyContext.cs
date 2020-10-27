using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace APIAuth.Models
{
    public class CompanyContext :DbContext
    {
        public CompanyContext() : base("name=DefaultConnection")
        {
            Database.SetInitializer(new DbInit());
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}