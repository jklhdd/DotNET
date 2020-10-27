using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApiSample.Models
{
    public class SchoolContext : DbContext
    {
        public SchoolContext() : base("name=connstring")
        {
            Database.SetInitializer(new DBInit());
        }
        public DbSet<Student> Students { get; set; }
    }
}