using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace WcfServiceApp
{
    class DbInit:DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            List<Student> students = new List<Student>()
            {
                new Student(){Id = 1, FirstName = "Long", LastName = "Dao", PhoneNumber = "12345678", Email="ac@gmail.com"},
                new Student(){Id = 2, FirstName = "Hai", LastName = "Nguyen", PhoneNumber = "11223344", Email="ad@gmail.com"},
                new Student(){Id = 3, FirstName = "Quan", LastName = "Tran", PhoneNumber = "22334455", Email="ae@gmail.com"},
            };
            context.Students.AddRange(students);
            context.SaveChanges();
            base.Seed(context); 
        }
    }
}
