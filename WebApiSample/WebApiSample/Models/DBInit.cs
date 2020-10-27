using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebApiSample.Models
{
    public class DBInit :DropCreateDatabaseIfModelChanges<SchoolContext>
    {
        protected override void Seed(SchoolContext context)
        {
            var students = new List<Student>()
            {
                new Student(){ Name= "Jame", JoinDate=new DateTime(2020,1,12)},
                new Student(){ Name= "Mary", JoinDate=new DateTime(2020,1,12)},
                new Student(){ Name= "Jack", JoinDate=new DateTime(2020,1,12)},
            };

            context.Students.AddRange(students);

            context.SaveChanges();
            base.Seed(context); 
        }

    }
}