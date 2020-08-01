using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace DBASP.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=connstring")
        {
            Database.SetInitializer(new InitDB());
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}