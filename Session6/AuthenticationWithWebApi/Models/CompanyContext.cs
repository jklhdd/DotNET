using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace AuthenticationWithWebApi.Models
{
    public class CompanyContext:DbContext
    {
        public CompanyContext() : base("name = DefaultConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<CompanyContext, Migrations.Configuration>());
        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}