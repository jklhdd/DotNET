using ExamEAP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ExamEAP
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in both code and config file together.
    public class StudentService : IStudentService
    {
        SchoolContext context = new SchoolContext();
        public List<Student> GetAllStudents()
        {
            return context.Students.ToList();
        }
    }
}
