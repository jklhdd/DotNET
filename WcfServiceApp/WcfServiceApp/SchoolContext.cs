using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WcfServiceApp
{
    class SchoolContext:DbContext
    {
        public SchoolContext():base("name=connstring")
        {
            Database.SetInitializer(new DbInit());
        }
        public DbSet<Student> Students { get; set; }
    }
}
