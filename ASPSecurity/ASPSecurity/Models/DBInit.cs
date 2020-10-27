using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Razor.Text;

namespace ASPSecurity.Models
{
    public class DBInit : DropCreateDatabaseIfModelChanges<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            List<Employee> employees = new List<Employee>()
            {
                new Employee(){Id = 1, Name = "Long", Address = "HaNoi"},
                new Employee(){Id = 2, Name = "Hai", Address = "DN"},
                new Employee(){Id = 3, Name = "Quan", Address = "HCM"},
            };
            context.Employees.AddRange(employees);
            context.SaveChanges();
            base.Seed(context);
        }
    }
}