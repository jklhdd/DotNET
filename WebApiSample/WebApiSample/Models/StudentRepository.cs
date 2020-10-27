using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApiSample.Models
{
    public class StudentRepository
    {
        private SchoolContext db;

        public StudentRepository()
        {
            db = new SchoolContext();
        }
        public List<Student> GetStudents()
        {
            return db.Students.ToList();
        }

        public Student GetStudent(int id)
        {
            return db.Students.Find(id);
        }

        public void Create(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();
        }
    }
}