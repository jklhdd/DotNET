using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace DBASP.Models
{
    public class InitDB : DropCreateDatabaseAlways<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            List<Department> departments = new List<Department>()
            {
                new Department(){Name = "Academy"},
                new Department(){Name = "HR"},
                new Department(){Name = "Marketing"},
                new Department(){Name = "CEO"}
            };
            context.Departments.AddRange(departments);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}