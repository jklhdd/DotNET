using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPSecurity.Models
{
    public class CompanyContext : DbContext
    {
        public CompanyContext() : base("name=connstring")
        {
            Database.SetInitializer(new DBInit());
        }

        public DbSet<Employee> Employees { get; set; }
    }
}