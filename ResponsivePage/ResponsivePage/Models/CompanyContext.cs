using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResponsivePage.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("name=connstring")
        {
            Database.SetInitializer(new DBInit());
        }

        public DbSet<Customer> Customers { get; set; }
    }
}