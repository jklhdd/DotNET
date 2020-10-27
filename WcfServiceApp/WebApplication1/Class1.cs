using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication1.ServiceReference1;

namespace WebApplication1
{
    public class Class1
    {
        static void Main(string[] args)
        {
            IStudentService service = new StudentServiceClient();
            var students = service.GetStudents();
            foreach (var student in students)
            {
                Console.WriteLine($"Id: {student.Id}, Name: {student.FirstName}");
            }
            Console.ReadLine();
        }
    }
}