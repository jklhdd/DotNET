using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ResponsivePage.Models
{
    public class DBInit : DropCreateDatabaseIfModelChanges<CompanyContext>
    {
        protected override void Seed(CompanyContext context)
        {
            List<Customer> customers = new List<Customer>() {
                        new Customer(){ Name="Jones",Region="East"},
                        new Customer(){ Name="Kivell",Region="Central"},
                        new Customer(){ Name="Jardine",Region="Central"},
                        new Customer(){ Name="Gill",Region="Central"},
                        new Customer(){ Name="Sorvino",Region="East"},
                        new Customer(){ Name="Andrews",Region="East"},
                        new Customer(){ Name="Thompson",Region="East"},
                        new Customer(){ Name="Morgan",Region="Central"},
                        new Customer(){ Name="Howard",Region="Central"},
                        new Customer(){ Name="Parent",Region="Central"},
                        new Customer(){ Name="Jardine",Region="Central"},
                        new Customer(){ Name="Sorvino",Region="East"}
            };
            context.Customers.AddRange(customers);
            context.SaveChanges();
            base.Seed(context); 
        }
    }
}